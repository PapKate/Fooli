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
        public bool IsChecked { get; set; } = false;

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

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CheckListItemEntity"/> from the specified <para
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CheckListItemEntity FromRequestModel(int noteId, CheckListItemRequestModel model)
        {
            var entity = DI.GetMapper.Map<CheckListItemEntity>(model);

            entity.NoteId = noteId;

            return entity;
        }

        /// <summary>
        /// Creates and returns a <see cref="CheckListItemResponseModel"/> from the current <see cref="CheckListItemEntity"/>
        /// </summary>
        /// <returns></returns>
        public CheckListItemResponseModel ToResponseModel()
        {
            return DI.GetMapper.Map<CheckListItemResponseModel>(this);
        }

        #endregion
    }
}
