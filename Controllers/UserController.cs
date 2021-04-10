using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
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

        /// <summary>
        /// The auto mapper
        /// </summary>
        private readonly IMapper mMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserController(FooliDBContext context, IMapper mapper)
        {
            mContext = context;

            mMapper = mapper;
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
            => ControllersHelper.PostAsync<UserRequestModel, UserEntity, UserResponseModel>(mContext, mContext.Users, mMapper, model);

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// Get fooli/users
        [HttpGet]
        [Route(Routes.UsersRoute)]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync()
        {
            // Gets the response models for each user entity
            var userResponseModels = await ControllersHelper.GetAllAsync<UserRequestModel, UserEntity, UserResponseModel>(mContext.Users, mMapper);
            // Returns the response models
            return userResponseModels;
        }

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="id">The user's id</param>
        /// Get fooli/users/{id} == fooli/users/2
        [HttpGet]
        [Route(Routes.UserRoute)]
        public async Task<ActionResult<UserResponseModel>> GetUserAsync([FromRoute]int userId)
        {
            // Gets the response model 
            var userResponseModel = await ControllersHelper.GetAsync<UserRequestModel, UserEntity, UserResponseModel>(mContext.Users, mMapper, userId);

            // Returns it
            return userResponseModel;
        }

        /// <summary>
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="model">The user request model</param>
        /// Put /fooli/users/{id}
        [HttpPut]
        [Route(Routes.UserRoute)]
        public async Task<ActionResult<UserResponseModel>> UpdateUserAsync([FromRoute]int id, [FromBody] UserRequestModel model)
        {
            // Gets the user with the specified id from the database 
            var user = await mContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            // If there is no user...
            if (user == null)
                // Return not found
                return NotFound();

            // If the model has a username...
            if (model.Username != null)
                // Set the user's username equal to the model's
                user.Username = model.Username;

            // If the model has a Email...
            if (model.Email != null)
                // Set the user's Email equal to the model's
                user.Email = model.Email;

            // If the model has a Password...
            if (model.Password != null)
                // Set the user's Password equal to the model's
                user.Password = model.Password;

            // If the model has a PictureUrl...
            if (model.PictureUrl != null)
                // Set the user's PictureUrl equal to the model's
                user.PictureUrl = model.PictureUrl;

            // If the model has a type...
            if (model.Type != null)
                // Set the user's username equal to the model's
                user.Type = model.Type.Value;

            // If the model has a FirstName...
            if (model.FirstName != null)
                // Set the user's FirstName equal to the model's
                user.FirstName = model.FirstName;

            // If the model has a LastName...
            if (model.LastName != null)
                // Set the user's LastName equal to the model's
                user.LastName = model.LastName;

            // If the model has a Gender...
            if (model.Gender != null)
                // Set the user's Gender equal to the model's
                user.Gender = model.Gender.Value;

            // If the model has a country...
            if (model.Country != null)
                // Set the user's Country equal to the model's
                user.Country = model.Country;

            // If the model has a City...
            if (model.City != null)
                // Set the user's City equal to the model's
                user.City = model.City;

            // If the model has a Address1...
            if (model.Address1 != null)
                // Set the user's Address1 equal to the model's
                user.Address1 = model.Address1;

            // If the model has a Address2...
            if (model.Address2 != null)
                // Set the user's Address2 equal to the model's
                user.Address2 = model.Address2;

            // If the model has a PostalCode...
            if (model.PostalCode != null)
                // Set the user's PostalCode equal to the model's
                user.PostalCode = model.PostalCode;

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            // Returns the user
            return mMapper.Map<UserResponseModel>(user);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="id">The user's id</param>
        /// Delete /fooli/users/{id}
        [HttpDelete]
        [Route(Routes.UserRoute)]
        public async Task<ActionResult<UserResponseModel>> DeleteUserAsync(int id)
        {
            // Gets the user from the database with id the specified id
            var user = await mContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            // If there is no user...
            if (user == null)
                // Return not found
                return NotFound();

            // Remove from the db context the user
            mContext.Users.Remove(user);

            // Save the changes to the database
            await mContext.SaveChangesAsync();

            // Returns the deleted user
            return mMapper.Map<UserResponseModel>(user);
        }

        #endregion

    }
}
