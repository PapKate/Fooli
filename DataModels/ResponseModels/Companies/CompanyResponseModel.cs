namespace Fooli
{
    /// <summary>
    /// The company's response model
    /// </summary>
    public class CompanyResponseModel : BaseResponseModel
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
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the logo image
        /// </summary>
        public string LogoImageName { get; set; }

        /// <summary>
        /// The logo image's url
        /// </summary>
        public string LogoImageSource { get; set; }

        /// <summary>
        /// The logo image's alternative text
        /// </summary>
        public string LogoImageAlt { get; set; }

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
        public CompanyResponseModel()
        {

        }

        #endregion
    }
}
