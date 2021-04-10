using System;

namespace Fooli
{
    public class BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

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
