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
    public class LabelEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The date the label was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the label was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

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
