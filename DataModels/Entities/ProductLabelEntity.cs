using System;

namespace Fooli
{
    /// <summary>
    /// Represents a product label pair in the database
    /// </summary>
    public class ProductLabelEntity
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

        #region Relationships

        /// <summary>
        /// The <see cref="ProductEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The <see cref="LabelEntity.Id"/> of the related <see cref="LabelEntity"/>
        /// </summary>
        public int LabelId { get; set; }

        /// <summary>
        /// The related <see cref="LabelEntity"/>
        /// </summary>
        public LabelEntity Label { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductLabelEntity()
        {

        }

        #endregion

    }
}
