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
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dBContext">The db context</param>
        /// <param name="dbSet">The db set</param>
        /// <param name="entity">The model</param>
        /// <param name="projector">Creates a <typeparamref name="TResponseModel"/> from the inserted <typeparamref name="TEntity"/></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> PostAsync<TEntity, TResponseModel>(FooliDBContext dBContext, DbSet<TEntity> dbSet, TEntity entity, Func<TEntity, TResponseModel> projector)
            where TEntity : class
        {
            // Add it to the database
            dbSet.Add(entity);

            // Save the changes in the database
            await dBContext.SaveChangesAsync();

            // Create a response model from the entity
            var responseModel = projector(entity);

            // Returns the response model
            return responseModel;
        }

        /// <summary>
        /// Gets all the response models of a db set
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="query">The db set</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<ActionResult<IEnumerable<TResponseModel>>> GetAllAsync<TEntity, TResponseModel>(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> filter)
            where TEntity : BaseEntity
        {
            // Gets the all the entities of the db set 
            var entities = await query.Where(filter).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the response models of the entities
            return new OkObjectResult(DI.GetMapper.Map<IEnumerable<TResponseModel>>(entities));
        }

        /// <summary>
        /// Gets a specified response model of an entity if exists with the specified id
        /// </summary>
        /// <typeparam name="TRequestModel">The request model</typeparam>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dbSet">The db set</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> GetAsync<TRequestModel, TEntity, TResponseModel>(IQueryable<TEntity> dbSet, IMapper mapper, Expression<Func<TEntity, bool>> filter)
            where TEntity : BaseEntity
        {
            // If exists finds the entity
            var entity = await dbSet.FirstOrDefaultAsync(filter, cancellationToken: default);

            // If the entity does not exist...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Return the response model of the entity
            return mapper.Map<TResponseModel>(entity);
        }

        public static Task<ActionResult<TResponseModel>> UpdateAsync<TRequestModel, TEntity, TResponseModel>()
        {
            return null;
        }

        /// <summary>
        /// Deletes the entity that follows the expression if exists
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dbContext">The db context</param>
        /// <param name="queryable">The db set</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="expression">The expression</param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> DeleteAsync<TEntity, TResponseModel>(DbContext dbContext, IQueryable<TEntity> queryable, IMapper mapper, Expression<Func<TEntity, bool>> expression)
            where TEntity : BaseEntity 
        {
            // Gets the entity if exists
            var entity = await queryable.FirstOrDefaultAsync(expression);

            // If no entity is found...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Removes the entity from the db set
            dbContext.Remove(entity);

            // Saves the changes to the data base
            await dbContext.SaveChangesAsync();

            // Returns the response model of the entity that was removed
            return mapper.Map<TResponseModel>(entity);
        }

        /// <summary>
        /// Creates and returns a <typeparamref name="TEntity"/> from the specified <typeparamref name="TRequestModel"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TRequestModel"></typeparam>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TEntity FromRequestModel<TEntity, TRequestModel>(TRequestModel model, Action<TEntity> action = null)
            where TEntity :  BaseEntity
        {
            // Maps the request model to the entity
            var entity = DI.GetMapper.Map<TEntity>(model);
            if(action!=null)
            {
                // Calls the action
                action.Invoke(entity);
            }

            // Returns the entity
            return entity;
        }

        /// <summary>
        /// Creates and returns a <typeparamref name="TResponseModel"/> from a <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TResponseModel"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TResponseModel ToResponseModel<TEntity, TResponseModel>(TEntity entity)
            where TResponseModel : BaseResponseModel => DI.GetMapper.Map<TResponseModel>(entity);

        /// <summary>
        /// Includes in a db set all the navigation properties if they exist
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <param name="dbSet">The db set</param>
        /// <param name="navigationPropertyNames">The names of the navigation properties</param>
        /// <returns></returns>
        public static IQueryable<TEntity> IncludeNavigationProperties<TEntity>(this IQueryable<TEntity> dbSet, params string[] navigationPropertyNames)
            where TEntity : BaseEntity 
        {
            // If there is at least one navigation property name...
            if (navigationPropertyNames.Length != 0)
            {
                // For each name...
                foreach (var navigationPropertyName in navigationPropertyNames)
                {
                    // Include them in the db set
                    dbSet = dbSet.Include(navigationPropertyName);
                }
            }
            // Return the db set
            return dbSet;
        }

        /// <summary>
        /// Parses the navigation properties to the correct form to include them later to a db set
        /// </summary>
        /// <param name="navigationPropertyNames">The names of the navigation properties</param>
        /// <returns></returns>
        public static string ParseToMultiLevelNavigationProperties(params string[] navigationPropertyNames)
        {
            // The path
            var navigationPropertyPath = string.Empty;
            
            // If there is at least one navigation property name...
            if (navigationPropertyNames.Length != 0)
            {
                // For each name...
                foreach (var navigationPropertyName in navigationPropertyNames)
                {
                    // If it is the last...
                    if (navigationPropertyName == navigationPropertyNames[navigationPropertyNames.Length - 1])
                        // Adds the name
                        navigationPropertyPath += $"{navigationPropertyName}";
                    // Else...
                    else
                        // Adds the name and a dot
                        navigationPropertyPath += $"{navigationPropertyName}.";
                }
            }

            // Returns the path
            return navigationPropertyPath;
        }

        #endregion
    }

}
