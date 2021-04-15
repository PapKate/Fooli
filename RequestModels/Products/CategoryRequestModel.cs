namespace Fooli
{
    /// <summary>
    /// The category's request model
    /// </summary>
    public class CategoryRequestModel : BaseRequestModel
    {
        #region Public Regions

        /// <summary>
        /// The category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The category icon's path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The id of the parent category
        /// </summary>
        public int? ParentCategoryId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryRequestModel()
        {

        }

        #endregion
    }
}
