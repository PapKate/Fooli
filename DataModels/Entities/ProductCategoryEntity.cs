using System;

namespace Fooli
{
    /// <summary>
    /// Represents a category product pair
    /// </summary>
    public class ProductCategoryEntity
    {
        #region Public Properties

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the image was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

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
        /// The <see cref="CategoryEntity.Id"/> of the related <see cref="CategoryEntity"/>
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The related <see cref="CategoryEntity"/>
        /// </summary>
        public CategoryEntity Category { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductCategoryEntity()
        {

        }

        #endregion

    }
}
