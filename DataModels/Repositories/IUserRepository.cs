using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Gets all the existing users
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntity> GetUsers();

        /// <summary>
        /// Gets the user with the specified ID if exists...
        /// Else throws error
        /// </summary>
        /// <param name="userId">The desired user's id</param>
        /// <returns></returns>
        UserEntity GetUserByID(int userId);

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">The user</param>
        void InsertUser(UserEntity user);

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="user">The user</param>
        void DeleteUser(UserEntity user);

        /// <summary>
        /// Updates a user's data in the database
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(UserEntity user);

        /// <summary>
        /// Saves changes in the database
        /// </summary>
        void SaveChanges();
    }
}
