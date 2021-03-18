using System;
using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a note in the database
    /// </summary>
    public class NoteEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
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
