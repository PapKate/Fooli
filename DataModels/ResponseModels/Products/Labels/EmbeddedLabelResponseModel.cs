namespace Fooli
{
    /// <summary>
    /// The embedded response model of a label entity
    /// </summary>
    public class EmbeddedLabelResponseModel : BaseResponseModel
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
        /// The value
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedLabelResponseModel()
        {

        }

        #endregion
    }
}
