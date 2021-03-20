namespace Fooli
{
    /// <summary>
    /// The string the represent the API routes
    /// </summary>
    public class Routes
    {
        /// <summary>
        /// The home route
        /// </summary>
        public const string HomeRoute = "fooli";

        /// <summary>
        /// The route for the users
        /// /fooli/users
        /// </summary>
        public const string UsersRoute = HomeRoute + "/users";

        /// <summary>
        /// The route for a users with id
        /// /fooli/users/1
        /// </summary>
        public const string UserRoute = UsersRoute + "/{id}";

        /// <summary>
        /// The route for the lists
        /// </summary>
        public const string ListsRoute = HomeRoute + "/lists";

        /// <summary>
        /// The route for the lists
        /// </summary>
        public const string UserListsRoute = UserRoute + "/lists";

        /// <summary>
        /// The route for a list with id
        /// </summary>
        public const string ListRoute = ListsRoute + "/{id}";


    }
}
