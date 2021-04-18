using System;
using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a company's product
    /// </summary>
    public class CompanyProductEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

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

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The <see cref="ProductEntity"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int? ProductrId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The prices per measurement of the product
        /// </summary>
        public IEnumerable<PricePerMeasurementUnitEntity> PricesPerMeasurementUnits { get; set; } 

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

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CompanyProductEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="productId">The product's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CompanyProductEntity FromRequestModel(int companyId, int productId, CompanyProductRequestModel model) 
            => ControllersHelper.FromRequestModel(model, delegate (CompanyProductEntity entity)
                                                        {
                                                            entity.CompanyId = companyId;
                                                            entity.ProductrId = productId;
                                                        });

        /// <summary>
        /// Creates and returns a <see cref="CompanyProductResponseModel"/> from the current <see cref="CompanyProductEntity"/>
        /// </summary>
        /// <returns></returns>
        public CompanyProductResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<CompanyProductEntity, CompanyProductResponseModel>(this);

        #endregion
    }
}
