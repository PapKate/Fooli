using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// The product measurement unit pair response model
    /// </summary>
    public class ProductMeasurementUnitResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="ProductResponseModel.Id"/> of the related <see cref="ProductResponseModel"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductResponseModel"/>
        /// </summary>
        public ProductResponseModel Product { get; set; }

        /// <summary>
        /// The <see cref="ProductMeasurementUnitResponseModel.Id"/> of the related <see cref="ProductMeasurementUnitResponseModel"/>
        /// </summary>
        public int MeasurementUnitId { get; set; }

        /// <summary>
        /// The related <see cref="MeasurementUnit"/>
        /// </summary>
        public ProductMeasurementUnitResponseModel MeasurementUnit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductMeasurementUnitResponseModel()
        {

        }

        #endregion
    }
}
