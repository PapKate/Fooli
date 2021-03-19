using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a category in the database
    /// </summary>
    public class CategoryEntity
    {
        #region Public Regions

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The icon's path
        /// </summary>
        public string Path { get; set; }

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
