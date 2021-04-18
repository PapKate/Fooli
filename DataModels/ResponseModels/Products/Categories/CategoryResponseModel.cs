using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// The category response model
    /// </summary>
    public class CategoryResponseModel : BaseResponseModel
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
        /// The id of the parent category
        /// The <see cref="CategoryResponseModel.Id"/> of the related <see cref="CategoryResponseModel"/>
        /// </summary>
        public int? ParentCategoryId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryResponseModel()
        {

        }

        #endregion
    }
}
