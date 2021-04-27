using System;

namespace Fooli
{
    /// <summary>
    /// The image response model
    /// </summary>
    public class ImageResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The image's url
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The image's alternative text
        /// </summary>
        public string Alt { get; set; }

        /// <summary>
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="BranchEntity"/>
        /// </summary>
        public int? BranchId { get; set; }

        /// <summary>
        /// The company's product's image
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="CompanyProductEntity"/>
        /// </summary>
        public int? CompanyProductId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImageResponseModel()
        {

        }

        #endregion
    }
}
