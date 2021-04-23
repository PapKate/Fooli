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
        public IEnumerable<CompanyProductEntity> CompaniesProducts { get; set; }

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
            // Maps the entity to a response model
            var response = ControllersHelper.ToResponseModel<ProductEntity, ProductResponseModel>(this);

            // Sets the response's categories as the categories in the pair
            response.Categories = ProductCategories?.Select(x => ControllersHelper.ToResponseModel<CategoryEntity, EmbeddedCategoryResponseModel>(x.Category)).ToList();

            // Sets the company products to the parsed from entities to embedded response models
            response.CompaniesProducts = CompaniesProducts?.Select(x => ControllersHelper.ToResponseModel<CompanyProductEntity, EmbeddedCompanyProductResponseModel>(x)).ToList();

            // Sets the response's labels as the labels in the pair parsed to embedded response models
            response.Labels = ProductLabels?.Select(x => ControllersHelper.ToResponseModel<LabelEntity, EmbeddedLabelResponseModel>(x.Label)).ToList();

            // For each label in the response...
            foreach(var label in response.Labels)
            {
                // Sets the label's value as the value of the label with the same id
                label.Value = ProductLabels?.FirstOrDefault(x => x.LabelId == label.Id).Value;
            }

            // Returns the response
            return response;
        }

        #endregion
    }
}
