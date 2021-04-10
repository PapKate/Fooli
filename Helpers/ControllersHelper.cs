using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Helper - additional methods for all the controllers
    /// </summary>
    public static class ControllersHelper
    {
        #region Public Methods

        /// <summary>
        /// Creates a post request
        /// </summary>
        /// <typeparam name="TRequestModel">The request model</typeparam>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dBContext">The db context</param>
        /// <param name="dbSet">The db set</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="model">The model</param>
        /// <param name="configureEntity">Extra modification</param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> PostAsync<TRequestModel, TEntity, TResponseModel>(FooliDBContext dBContext, DbSet<TEntity> dbSet, IMapper mapper, TRequestModel model, Action<TEntity> configureEntity = null)
            where TEntity : class
        {
            // Creates an entity from the specified model
            var entity = mapper.Map<TEntity>(model);

            configureEntity?.Invoke(entity);

            // Add it to the database
            dbSet.Add(entity);

            // Save the changes in the database
            await dBContext.SaveChangesAsync();

            // Create a response model from the entity
            var responseModel = mapper.Map<TResponseModel>(entity);

            // Returns the response model
            return responseModel;
        }

        /// <summary>
        /// Gets all the response models of a db set
        /// </summary>
        /// <typeparam name="TRequestModel">The request model</typeparam>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dbSet">The db set</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static async Task<ActionResult<IEnumerable<TResponseModel>>> GetAllAsync<TRequestModel, TEntity, TResponseModel>(IQueryable<TEntity> dbSet, IMapper mapper, params string[] navigationPropertyNames)
            where TEntity : BaseEntity
        {
            // Gets the all the entities of the db set 
            var entities = new List<TEntity>();

            // If there is at least one navigation property name...
            if(navigationPropertyNames.Length != 0)
            {
                foreach(var navigationPropertyName in navigationPropertyNames)
                {
                    dbSet = dbSet.Include(navigationPropertyName);
                }
            }

            // Gets the all the entities of the db set 
            entities = await dbSet.ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the response models of the entities
            return new OkObjectResult(mapper.Map<IEnumerable<TResponseModel>>(entities));
        }

        /// <summary>
        /// Gets a specified response model of an entity if exists with the specified id
        /// </summary>
        /// <typeparam name="TRequestModel">The request model</typeparam>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dbSet">The db set</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="id">The id</param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> GetAsync<TRequestModel, TEntity, TResponseModel>(IQueryable<TEntity> dbSet, IMapper mapper, int id, params string[] navigationPropertyNames)
            where TEntity : BaseEntity
        {
            // If exists finds the entity
            var entity = await dbSet.FirstOrDefaultAsync<TEntity>(x => x.Id == id);

            // If the entity does not exist...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Return the response model of the entity
            return mapper.Map<TResponseModel>(entity);
        }




        #endregion
    }

}
