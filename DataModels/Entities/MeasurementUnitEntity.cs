using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// 
    /// </summary>
    public class MeasurementUnitEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name 
        /// ex. kilograms
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The quantity
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// The abbreviation
        /// </summary>
        public string Αbbreviation { get; set; }

        #region Relationships

        /// <summary>
        /// The product measurement units
        /// </summary>
        public IEnumerable<ProductMeasurementUnitEntity> ProductMeasurementUnits { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeasurementUnitEntity()
        {

        }

        #endregion
    }
}
