using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The product's response model
    /// </summary>
    public class ProductResponseModel : BaseResponseModel
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

        ///// <summary>
        ///// The product's images
        ///// </summary>
        //public IEnumerable<ImageResponseModel> Images { get; set; }

        ///// <summary>
        ///// The companies and products
        ///// </summary>
        //public IEnumerable<CompanyProductResponseModel> CompaniesProducts { get; set; }

        ///// <summary>
        ///// The labels and products
        ///// </summary>
        //public IEnumerable<ProductLabelResponseModel> ProductLabels { get; set; }

        /// <summary>
        /// The category and product pairs
        /// </summary>
        public IEnumerable<EmbeddedCategoryResponseModel> Categories { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductResponseModel()
        {

        }

        #endregion
    }
}
