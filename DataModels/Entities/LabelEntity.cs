using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a label in the database
    /// </summary>
    public class LabelEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The labels and products
        /// </summary>
        public IEnumerable<ProductLabelEntity> ProductLabels { get; set; }

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
