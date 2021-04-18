namespace Fooli
{
    /// <summary>
    /// Represents a category product pair
    /// </summary>
    public class ProductCategoryEntity : BaseEntity
    {
        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CategoryEntity"/>
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
