using System;

namespace Fooli
{
    /// <summary>
    /// Does not have id
    /// </summary>
    public class BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date it was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseResponseModel()
        {

        }

        #endregion
    }
}
