namespace Fooli
{
    /// <summary>
    /// Represents a list item in the database
    /// </summary>
    public class CheckListItemEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Shows if it is checked
        /// </summary>
        public bool IsChecked { get; set; }

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
