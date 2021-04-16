using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// The response model for the leaflet
    /// </summary>
    public class LeafletResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The date from which the leaflet applies
        /// </summary>
        public DateTimeOffset DateStart { get; set; }

        /// <summary>
        /// The date that ends what the leaflet applies
        /// </summary>
        public DateTimeOffset DateEnd { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LeafletResponseModel()
        {

        }

        #endregion
    }
}
