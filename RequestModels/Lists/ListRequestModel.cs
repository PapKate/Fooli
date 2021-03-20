using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The list's request model
    /// </summary>
    public class ListRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The list's items
        /// </summary>
        public IEnumerable<ListItemEntity> ListItems { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListRequestModel()
        {

        }

        #endregion
    }
}
