using System;

namespace Fooli
{
    public class ImageResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the image was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

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

        ///// <summary>
        ///// The <see cref="ProductEntity.Id"/> of the related <see cref="ProductEntity"/>
        ///// </summary>
        //public int? ProductId { get; set; }

        /// <summary>
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int? CompanyId { get; set; }

        ///// <summary>
        ///// The company's product's image
        ///// The <see cref="CompanyProductEntity.Id"/> of the related <see cref="CompanyProductEntity"/>
        ///// </summary>
        //public int? CompanyProductId { get; set; }

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
