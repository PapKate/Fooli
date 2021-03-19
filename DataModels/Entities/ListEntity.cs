using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a note in the database
    /// </summary>
    public class ListEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The date the note was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        #region Relationships

        /// <summary>
        /// The list's items
        /// </summary>
        public IEnumerable<ListItemEntity> ListItems { get; set; }

        /// <summary>
        /// The <see cref="UserEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity User { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListEntity()
        {

        }

        #endregion
    }
}
