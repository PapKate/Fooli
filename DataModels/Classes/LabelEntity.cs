using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a label in the database
    /// </summary>
    public class LabelEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The label's name
        /// </summary>
        public Label Label { get; set; }

        #region Relationships

        /// <summary>
        /// The label options
        /// </summary>
        public IEnumerable<LabelOptionEntity> LabelOptions { get; set; }

        /// <summary>
        /// The label and product pairs
        /// </summary>
        public IEnumerable<LabelsProductsEntity> LabelsProducts { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelEntity()
        {

        }

        #endregion

    }
}
