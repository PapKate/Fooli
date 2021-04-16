namespace Fooli
{
    /// <summary>
    /// The product measurement unit pair request model
    /// </summary>
    public class ProductMeasurementUnitRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductRequestModel.Id"/> of the related <see cref="ProductRequestModel"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The <see cref="ProductMeasurementUnitRequestModel.Id"/> of the related <see cref="ProductMeasurementUnitRequestModel"/>
        /// </summary>
        public int MeasurementUnitId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductMeasurementUnitRequestModel()
        {

        }

        #endregion
    }
}
