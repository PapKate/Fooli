using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    public class LeafletResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

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
        public DateTimeOffset DateStart { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date that ends what the leaflet applies
        /// </summary>
        public DateTimeOffset DateEnd { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
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
