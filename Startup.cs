using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Fooli
{
    /// <summary>
    /// The start up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FooliDBContext>(options => options.UseSqlServer
                (Configuration.GetConnectionString("FooliSQLServerConnection")));

            #region AutoMapper

            var configuration = new MapperConfiguration((cfg) =>
            {
                // The request model types
                var requestModelTypes = new List<Type>();

                // The entity types
                var entityTypes = new List<Type>();

                // The response model types
                var responseModelTypes = new List<Type>();

                var assemblies = new List<Assembly>()
                {
                    // The request model
                    Assembly.GetAssembly(typeof(UserRequestModel)),
                    // The entities
                    Assembly.GetAssembly(typeof(UserEntity)),
                    // The response models
                    Assembly.GetAssembly(typeof(UserResponseModel))
                };

                // For each assembly...
                foreach (var assembly in assemblies)
                {
                    // For each type...
                    foreach (var type in assembly.GetTypes())
                    {
                        // If the type ends with "RequestModel"...
                        if (type.Name.EndsWith(FrameworkConstructionExtensions.RequestModelSuffix))
                            // Add it to the request model types
                            requestModelTypes.Add(type);
                        // Else if the type ends with "Entity"...
                        else if (type.Name.EndsWith(FrameworkConstructionExtensions.EntitySuffix))
                            // Add it to the entity types
                            entityTypes.Add(type);
                        // Else if the type ends with "ResponseModel"...
                        else if (type.Name.EndsWith(FrameworkConstructionExtensions.ResponseModelSuffix))
                            // Add it to the response model types
                            responseModelTypes.Add(type);
                    }

                    // For each request model type...
                    foreach (var requestModelType in requestModelTypes)
                    {
                        // Get the prefix of the model
                        var requestModelNamePrefix = requestModelType.Name.Replace(FrameworkConstructionExtensions.RequestModelSuffix, string.Empty);
                        // Get the entity type if exists with the same prefix
                        var entityType = entityTypes.FirstOrDefault(x => x.Name.Replace(FrameworkConstructionExtensions.EntitySuffix, string.Empty) == requestModelNamePrefix);

                        // If the entity type exists...
                        if (entityType != null)
                            // Create map for request model -> entity
                            cfg.CreateMap(requestModelType, entityType);
                    }

                    // For each entity type
                    foreach (var entityType in entityTypes)
                    {
                        // Get the prefix of the entity
                        var entityNamePrefix = entityType.Name.Replace(FrameworkConstructionExtensions.EntitySuffix, string.Empty);
                        // Get the response model type if exists with the same prefix
                        var responseModelType = responseModelTypes.FirstOrDefault(x => x.Name.Replace(FrameworkConstructionExtensions.ResponseModelSuffix, string.Empty) == entityNamePrefix);

                        // If the response model exists...
                        if (responseModelType != null)
                            // Create map for entity -> response model
                            cfg.CreateMap(entityType, responseModelType);
                        
                        var embeddedResponseModelName = FrameworkConstructionExtensions.EmbeddedPrefix + entityNamePrefix + FrameworkConstructionExtensions.ResponseModelSuffix;

                        var embeddedResponseModelType = responseModelTypes.FirstOrDefault(x => x.Name == embeddedResponseModelName);

                        if (embeddedResponseModelType == null)
                            continue;

                        cfg.CreateMap(entityType, embeddedResponseModelType);
                    }
                }

                cfg.ForAllPropertyMaps(propertyMap => propertyMap.TypeMap.SourceType.Name.EndsWith(FrameworkConstructionExtensions.RequestModelSuffix)
                                                                                               && (TypeHelpers.GetNonNullableType(propertyMap.SourceType) == propertyMap.DestinationType
                                                                                                || propertyMap.SourceType == propertyMap.DestinationType),
                                      (proptertyMap, c) =>
                                      {
                                          c.MapFrom(new IgnoreNullResolver(), proptertyMap.SourceMember.Name);
                                      });
            });

            // Create the mapper
            var mapper = new Mapper(configuration);

            // Add the mapper to the services
            services.AddSingleton(mapper);

            #endregion

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, FooliDBContext dBContext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                dBContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            await EntryPoint.SetUpAsync(dBContext);
        }
    }
}
