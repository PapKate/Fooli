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
        /// The route for the all notes
        /// /fooli/notes/
        /// </summary>
        public const string NotesRoute = HomeRoute + "/notes";

        /// <summary>
        /// The route for a note with specified id
        /// /fooli/notes/3
        /// </summary>
        public const string NoteRoute = NotesRoute + "/{noteId}";

        /// <summary>
        /// The route for the all images
        /// </summary>
        public const string ImagesRoute = HomeRoute + "/images";

        /// <summary>
        /// The route for an image with specified id
        /// </summary>
        public const string ImageRoute = ImagesRoute + "/{imageId}";

        #region User Routes

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

        #region Notes

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

        #region Check List Items

        /// <summary>
        /// The route for a user note's check list items
        /// fooli/users/2/notes/1/checkListItems
        /// </summary>
        public const string UserNoteCheckListItems = UserNoteRoute + "/checkListItems";

        /// <summary>
        /// The route for a user note's check list item
        /// fooli/users/2/notes/1/checkListItems/3
        /// </summary>
        public const string UserNoteCheckListItem = UserNoteCheckListItems + "/{checkListItemId}";

        #endregion

        #endregion

        #endregion

        #region Company routes

        /// <summary>
        /// The route for all companies
        /// fooli/companies
        /// </summary>
        public const string CompaniesRoute = HomeRoute + "/companies";

        /// <summary>
        /// The route for a company with specified id
        /// fooli/companies/2
        /// </summary>
        public const string CompanyRoute = CompaniesRoute + "/{companyId}";

        /// <summary>
        /// The route for the all images of a company
        /// fooli/companies/2/images
        /// </summary>
        public const string CompanyImagesRoute = CompanyRoute + "/images";

        /// <summary>
        /// The route for a company's image with specified image id and company id
        /// fooli/companies/2/images/5
        /// </summary>
        public const string CompanyImageRoute = CompanyImagesRoute + "/{imageId}";

        #region Company leaflets routes 

        /// <summary>
        /// The route of a company's leaflets
        /// fooli/companies/1/leaflets
        /// </summary>
        public const string CompanyLeafletsRoute = CompanyRoute + "/leaflets";

        /// <summary>
        /// The route of a company's leaflet
        /// fooli/companies/1/leaflets/3
        /// </summary>
        public const string CompanyLeafletRoute = CompanyLeafletsRoute+ "/{leafletId}";

        #endregion

        #region Company products routes

        /// <summary>
        /// The route of a company's products
        /// fooli/companies/2/companyProducts
        /// </summary>
        public const string CompanyProductsRoute = CompanyRoute + "/companyProducts";

        /// <summary>
        /// The route of a company's product
        /// fooli/companies/2/companyProducts/3
        /// </summary>
        public const string CompanyProductRoute = CompanyProductsRoute + "/{companyProductId}";

        /// <summary>
        /// The route for the all images of a company's product
        /// fooli/companies/2/companyProducts/3/images
        /// </summary>
        public const string CompanyProductImagesRoute = CompanyProductRoute + "/images";

        /// <summary>
        /// The route for an image of a company's product with specified image id and company product id
        /// fooli/companies/2/companyProducts/3/images/1
        /// </summary>
        public const string CompanyProductImageRoute = CompanyProductImagesRoute + "/{imageId}";

        #endregion

        #endregion

    }
}
