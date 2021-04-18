using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a category in the database
    /// </summary>
    public class CategoryEntity : BaseEntity
    {
        #region Public Regions

        /// <summary>
        /// The category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The category icon's path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        #region Relationships

        /// <summary>
        /// The id of the parent category
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CategoryEntity"/>
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// The related <see cref="CategoryEntity"/>
        /// </summary>
        public CategoryEntity ParentCategory { get; set; }

        /// <summary>
        /// The children categories
        /// </summary>
        public IEnumerable<CategoryEntity> ChildrenCategories { get; set; }

        /// <summary>
        /// The products categories pair
        /// </summary>
        public IEnumerable<ProductCategoryEntity> ProductCategories { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CategoryEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CategoryEntity FromRequestModel(CategoryRequestModel model)
            => ControllersHelper.FromRequestModel<CategoryEntity, CategoryRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CategoryResponseModel"/> from the current <see cref="CategoryEntity"/>
        /// </summary>
        /// <returns></returns>
        public CategoryResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<CategoryEntity, CategoryResponseModel>(this);

        #endregion
    }
}
