﻿namespace Fooli
{
    /// <summary>
    /// The embedded response model of a category entity
    /// </summary>
    public class EmbeddedCategoryResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedCategoryResponseModel()
        {

        }

        #endregion
    }
}
