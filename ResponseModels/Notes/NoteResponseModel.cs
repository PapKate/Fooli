using System;
using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The list's response model
    /// </summary>
    public class NoteResponseModel
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
        /// The text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The date the note was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the list was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// The list's items
        /// </summary>
        public IEnumerable<CheckListItemResponseModel> CheckListItems { get; set; }

        /// <summary>
        /// The <see cref="UserEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NoteResponseModel()
        {

        }

        #endregion
    }
}
