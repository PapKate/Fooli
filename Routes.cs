namespace Fooli
{
    /// <summary>
    /// The string the represent the API routes
    /// </summary>
    public class Routes
    {
        /// <summary>
        /// The home route
        /// /fooli
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
        public const string UserRoute = UsersRoute + "/{userId}";

        /// <summary>
        /// The route for a user's notes
        /// /fooli/users/1/notes
        /// </summary>
        public const string UserNotesRoute = UserRoute + "/notes";
      
        /// <summary>
        /// The route for a user's note with noteId and userId
        /// /fooli/users/1/notes/5
        /// </summary>
        public const string UserNoteRoute = UserNotesRoute + "/{noteId}";
        
        /// <summary>
        /// The route for the all notes
        /// /fooli/notes/
        /// </summary>
        public const string NotesRoute = HomeRoute + "/notes";

        /// <summary>
        /// The route for a note with specified id
        /// /fooli/notes/3
        /// </summary>
        public const string NoteRoute = NotesRoute + "/{noteId}";


    }
}
