using System;

namespace Fooli
{
    /// <summary>
    /// Represents a product label pair in the database
    /// </summary>
    public class ProductLabelEntity : BaseEntity
    {
        #region Public Properties

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
