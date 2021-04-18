﻿using System;

namespace Fooli
{
    /// <summary>
    /// The measurement unit's response model
    /// </summary>
    public class PricePerMeasurementUnitResponseModel : BaseResponseModel
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
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="CompanyProductResponseModel"/>
        /// </summary>
        public int CompanyProductId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyProductResponseModel"/>
        /// </summary>
        public CompanyProductResponseModel CompanyProduct { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PricePerMeasurementUnitResponseModel()
        {

        }

        #endregion
    }
}
