using AutoMapper;

namespace Fooli
{
    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per
    /// profile.
    /// </summary>
    public class UsersProfile : Profile
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersProfile()
        {
            // Source -> Target
            // Creates an auto mapper that maps the database's user table to the user get response model
            CreateMap<UserEntity, UserResponseModel>();

            // Creates an auto mapper that maps the user create request model to the database's user table
            CreateMap<UserRequestModel, UserEntity>();
        }

        #endregion

    }
}
