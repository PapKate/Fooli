using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Represents a label's option in the database
    /// </summary>
    public class LabelOptionEntity
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

        #region Relationships

        /// <summary>
        /// The <see cref="LabelEntity.Id"/> of the related <see cref="LabelEntity"/>
        /// </summary>
        public int LabelId { get; set; }

        /// <summary>
        /// The related <see cref="LabelEntity"/>
        /// </summary>
        public LabelEntity LabelEntity { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelOptionEntity()
        {

        }

        #endregion

    }
}
