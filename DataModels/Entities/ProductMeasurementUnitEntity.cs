namespace Fooli
{
    /// <summary>
    /// The product measurement unit pair entity
    /// </summary>
    public class ProductMeasurementUnitEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The <see cref="MeasurementUnitEntity.Id"/> of the related <see cref="MeasurementUnitEntity"/>
        /// </summary>
        public int MeasurementUnitId { get; set; }

        /// <summary>
        /// The related <see cref="MeasurementUnit"/>
        /// </summary>
        public MeasurementUnitEntity MeasurementUnit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductMeasurementUnitEntity()
        {

        }

        #endregion
    }
}
