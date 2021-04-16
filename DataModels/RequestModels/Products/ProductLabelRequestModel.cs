namespace Fooli
{
    /// <summary>
    /// The product label pair's request model
    /// </summary>
    public class ProductLabelRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductRequestModel.Id"/> of the related <see cref="ProductRequestModel"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The <see cref="LabelRequestModel.Id"/> of the related <see cref="LabelRequestModel"/>
        /// </summary>
        public int LabelId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductLabelRequestModel()
        {

        }

        #endregion
    }
}
