namespace Fooli
{
    /// <summary>
    /// The embedded version of a company entity
    /// </summary>
    public class EmbeddedCompanyResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The name of the text image
        /// </summary>
        public string TextImageName { get; set; }

        /// <summary>
        /// The text image's url
        /// </summary>
        public string TextImageSource { get; set; }

        /// <summary>
        /// The text image's alternative text
        /// </summary>
        public string TextImageAlt { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedCompanyResponseModel()
        {

        }  

        #endregion
    }
}
