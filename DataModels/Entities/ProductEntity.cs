using System.Collections.Generic;
using System.Linq;

namespace Fooli
{
    /// <summary>
    /// Represents a product in the database
    /// </summary>
    public class ProductEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public double Price { get; set; }

        #region Relationships

        /// <summary>
        /// The product's images
        /// </summary>
        public IEnumerable<ImageEntity> Images { get; set; }

        /// <summary>
        /// The product measurement units
        /// </summary>
        public IEnumerable<ProductMeasurementUnitEntity> ProductMeasurementUnits { get; set; }

        /// <summary>
        /// The companies and products
        /// </summary>
        public IEnumerable<CompanyProductEntity> CompanyProducts { get; set; }

        /// <summary>
        /// The labels and products
        /// </summary>
        public IEnumerable<ProductLabelEntity> ProductLabels { get; set; }

        /// <summary>
        /// The category and product pairs
        /// </summary>
        public IEnumerable<ProductCategoryEntity> ProductCategories { get; set; }
        
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

        #region Public Methods

        public static ProductEntity FromRequestModel(ProductRequestModel model, CompanyProductEntity companyProduct)
        {
           
            return ControllersHelper.FromRequestModel(model, delegate (ProductEntity entity) 
            {
            });
        }

        #endregion
    }
}
