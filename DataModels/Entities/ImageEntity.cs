using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents an image in the database
    /// </summary>
    public class ImageEntity : StandardEntity
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

        #region Relationships

        /// <summary>
        /// The <see cref="ProductEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The company's product's image
        /// The <see cref="CompanyProductEntity.Id"/> of the related <see cref="CompanyProductEntity"/>
        /// </summary>
        public int? CompanyProductId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyProductEntity"/>
        /// </summary>
        public CompanyProductEntity CompanyProduct { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImageEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ImageEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static ImageEntity FromRequestModel(int companyId, ImageRequestModel model) 
            => ControllersHelper.FromRequestModel(model, delegate (ImageEntity entity) { entity.CompanyId = companyId; });

        /// <summary>
        /// Creates and returns a <see cref="ImageResponseModel"/> from the current <see cref="ImageEntity"/>
        /// </summary>
        /// <returns></returns>
        public ImageResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<ImageEntity, ImageResponseModel>(this);

        #endregion

    }
}
