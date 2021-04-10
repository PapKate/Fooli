using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a note in the database
    /// </summary>
    public class NoteEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        #region Relationships

        /// <summary>
        /// The check list's items
        /// </summary>
        public IEnumerable<CheckListItemEntity> CheckListItems { get; set; }

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
        public NoteEntity()
        {

        }

        #endregion
    }
}
