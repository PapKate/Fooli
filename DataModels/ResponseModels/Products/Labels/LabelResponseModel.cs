using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The label response model
    /// </summary>
    public class LabelResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The labels and products
        /// </summary>
        public IEnumerable<ProductLabelResponseModel> ProductLabels { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelResponseModel()
        {

        }

        #endregion
    }
}
