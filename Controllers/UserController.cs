
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Api users
    /// </summary>
    public class UserController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly FooliDBContext mContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserController(FooliDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// Post fooli/users
        [HttpPost]
        [Route(Routes.UsersRoute)]
        public Task<ActionResult<UserResponseModel>> CreateUserAsync([FromBody] UserRequestModel model) 
            => ControllersHelper.PostAsync<UserEntity, UserResponseModel>(
                mContext, 
                mContext.Users, 
                UserEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// Get fooli/users
        [HttpGet]
        [Route(Routes.UsersRoute)]
        public Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync() =>
            // Gets the response models for each user entity
            ControllersHelper.GetAllAsync<UserEntity, UserResponseModel>(
                mContext.Users,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// Get fooli/users/{userId} == fooli/users/2
        [HttpGet]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> GetUserAsync([FromRoute]int userId)
        {
            // The needed expression for the filter
            Expression<Func<UserEntity, bool>> filter = x => x.Id == userId;

            // Gets the response model 
            return ControllersHelper.GetAsync<UserEntity, UserResponseModel>(
                mContext.Users, 
                DI.GetMapper, 
                filter);
        }

        /// <summary>
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="model">The user request model</param>
        /// Put /fooli/users/{userId}
        [HttpPut]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> UpdateUserAsync([FromRoute]int userId, [FromBody] UserRequestModel model)
        {
            return ControllersHelper.PutAsync<UserRequestModel, UserEntity, UserResponseModel>(
                mContext,
                mContext.Users,
                model,
                x => x.Id == userId);   
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// Delete /fooli/users/{userId}
        [HttpDelete]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> DeleteUserAsync(int userId)
        {
            return ControllersHelper.DeleteAsync<UserEntity, UserResponseModel>(
                mContext, 
                mContext.Users,
                DI.GetMapper,
                x => x.Id == userId);
        }

        #endregion

    }
}
