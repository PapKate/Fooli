using System;

namespace Fooli
{
    /// <summary>
    /// The company product request model
    /// </summary>
    public class CompanyProductRequestModel : BaseRequestModel
    {
        #region Public Properties

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
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The <see cref="ProductEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// If null create a new product
        /// </summary>
        public int? ProductId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyProductRequestModel()
        {

        }

        #endregion
    }
}
