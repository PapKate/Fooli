namespace Fooli
{
    /// <summary>
    /// The product category pair request model
    /// </summary>
    public class ProductCategoryRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductRequestModel.Id"/> of the related <see cref="ProductRequestModel"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The <see cref="CategoryRequestModel.Id"/> of the related <see cref="CategoryRequestModel"/>
        /// </summary>
        public int CategoryId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductCategoryRequestModel()
        {

        }

        #endregion
    }
}
