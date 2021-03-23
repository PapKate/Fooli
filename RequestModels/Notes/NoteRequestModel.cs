using System;
using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The list's request model
    /// </summary>
    public class NoteRequestModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NoteRequestModel()
        {

        }

        #endregion
    }
}
