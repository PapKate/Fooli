using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a company's product
    /// </summary>
    public class CompanyProductEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The product's price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The regular price
        /// </summary>
        public double RegularPrice { get; set; }

        /// <summary>
        /// The price of the product when on sale
        /// </summary>
        public double SalePrice { get; set; }

        /// <summary>
        /// Shows if product is on sale
        /// </summary>
        public bool IsOnSale { get; set; }

        /// <summary>
        /// Start date of sale price
        /// </summary>
        public DateTimeOffset DateOnSaleFrom { get; set; }

        /// <summary>
        /// End date of sale price
        /// </summary>
        public DateTimeOffset DateOnSaleTo { get; set; }

        /// <summary>
        /// Total number of products in stock
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Shows if the product can be bought
        /// </summary>
        public bool IsPurchasable { get; set; }

        /// <summary>
        /// The product is verified by the company
        /// </summary>
        public bool IsVerified { get; set; }

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
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The <see cref="ProductEntity"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int ProductrId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyProductEntity()
        {

        }

        #endregion

    }
}
