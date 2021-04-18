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

        #region Relationships

        /// <summary>
        /// The product's images
        /// </summary>
        public IEnumerable<ImageEntity> Images { get; set; }

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

        /// <summary>
        /// Creates and returns a <see cref="ProductEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static ProductEntity FromRequestModel(ProductRequestModel model)
            => ControllersHelper.FromRequestModel<ProductEntity, ProductRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="ProductResponseModel"/> from the current <see cref="ProductEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProductResponseModel ToResponseModel()
        {
            var response = ControllersHelper.ToResponseModel<ProductEntity, ProductResponseModel>(this);

            response.Categories = ProductCategories?.Select(x => ControllersHelper.ToResponseModel<CategoryEntity, EmbeddedCategoryResponseModel>(x.Category)).ToList();

            return response;
        }

        #endregion
    }
}
