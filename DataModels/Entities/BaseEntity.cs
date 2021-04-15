using System;

namespace Fooli
{
    /// <summary>
    /// The base entity with the date created and modified properties
    /// </summary>
    public class BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The date it was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity()
        {

        }

        #endregion
    }
}
