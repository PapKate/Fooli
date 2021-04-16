namespace Fooli
{
    /// <summary>
    /// The product label pair's response model
    /// </summary>
    public class ProductLabelResponseModel : BaseResponseModel
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
        /// The <see cref="LabelResponseModel.Id"/> of the related <see cref="LabelResponseModel"/>
        /// </summary>
        public int LabelId { get; set; }

        /// <summary>
        /// The related <see cref="LabelResponseModel"/>
        /// </summary>
        public LabelResponseModel Label { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductLabelResponseModel()
        {

        }

        #endregion
    }
}
