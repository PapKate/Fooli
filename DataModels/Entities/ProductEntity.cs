using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the image was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

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
        public IEnumerable<ProductCategoryEntity> ProductsCategories { get; set; }
        
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
