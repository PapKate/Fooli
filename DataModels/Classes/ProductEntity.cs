using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a product in the database
    /// </summary>
    public class ProductEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public double? Price { get; set; }

        #region Relationships

        /// <summary>
        /// The companies and products
        /// </summary>
        public IEnumerable<CompanyProductEntity> CompaniesProducts { get; set; }

        /// <summary>
        /// The label and product pairs
        /// </summary>
        public IEnumerable<LabelsProductsEntity> LabelsProducts { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductEntity()
        {

        }

        #endregion
    }
}
