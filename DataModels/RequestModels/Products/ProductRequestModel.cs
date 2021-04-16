namespace Fooli
{
    /// <summary>
    /// The product's request model
    /// </summary>
    public class ProductRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductRequestModel()
        {

        }

        #endregion
    }
}
