﻿namespace Fooli
{
    public class CheckListItemRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Shows if it is checked
        /// </summary>
        public bool? IsChecked { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CheckListItemRequestModel()
        {

        }

        #endregion
    }
}
