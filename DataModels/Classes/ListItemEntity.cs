namespace Fooli
{
    /// <summary>
    /// Represents a list item in the database
    /// </summary>
    public class ListItemEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        public string Item { get; set; }

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
        public ListItemEntity()
        {

        }

        #endregion

    }
}
