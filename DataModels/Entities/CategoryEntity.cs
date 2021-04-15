﻿using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a category in the database
    /// </summary>
    public class CategoryEntity : StandardEntity
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

        #region Relationships

        /// <summary>
        /// The id of the parent category
        /// The <see cref="CategoryEntity.Id"/> of the related <see cref="CategoryEntity"/>
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
    }
}
