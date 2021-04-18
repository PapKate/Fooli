using System;

namespace Fooli
{
    /// <summary>
    /// Represents a measurement unit in the data base
    /// </summary>
    public class PricePerMeasurementUnitEntity : BaseEntity
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
        /// ex. TM, kg, gr
        /// </summary>
        public string Αbbreviation { get; set; }

        /// <summary>
        /// The regular price
        /// </summary>
        public double RegularPrice { get; set; }

        /// <summary>
        /// The price of the product when on sale
        /// </summary>
        public double SalePrice { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyProductEntity"/>
        /// </summary>
        public int CompanyProductId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyProductEntity"/>
        /// </summary>
        public CompanyProductEntity CompanyProduct { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PricePerMeasurementUnitEntity()
        {

        }

        #endregion
    }
}
