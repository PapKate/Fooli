using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a list item in the database
    /// </summary>
    public class CheckListItemEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Shows if it is checked
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date it was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;

        #region Relationships

        /// <summary>
        /// The <see cref="NoteEntity.Id"/> of the related <see cref="NoteEntity"/>
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// The related <see cref="NoteEntity"/>
        /// </summary>
        public NoteEntity Note { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CheckListItemEntity()
        {

        }

        #endregion

    }
}
