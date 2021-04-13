using System;

namespace Fooli
{
    /// <summary>
    /// 
    /// </summary>
    public class LeafletRequestModel : BaseRequestModel
    {
        #region Pubic Properties

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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LeafletRequestModel()
        {

        }

        #endregion
    }
}
