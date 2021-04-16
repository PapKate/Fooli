namespace Fooli
{
    /// <summary>
    /// The label request model
    /// </summary>
    public class LabelRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug
        /// </summary>
        public string Slug { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelRequestModel()
        {

        }

        #endregion

    }
}
