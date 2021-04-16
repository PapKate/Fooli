namespace Fooli
{
    /// <summary>
    /// The product category pair's response model
    /// </summary>
    public class ProductCategoryResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductResponseModel.Id"/> of the related <see cref="ProductResponseModel"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductResponseModel"/>
        /// </summary>
        public ProductResponseModel Product { get; set; }

        /// <summary>
        /// The <see cref="CategoryResponseModel.Id"/> of the related <see cref="CategoryResponseModel"/>
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The related <see cref="CategoryResponseModel"/>
        /// </summary>
        public CategoryResponseModel Category { get; set; }

        #endregion

        #region Constructors 

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductCategoryResponseModel()
        {

        }

        #endregion
    }
}
