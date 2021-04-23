namespace Fooli
{
    /// <summary>
    /// Represents an image in the database
    /// </summary>
    public class ImageEntity : BaseEntity
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
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="BranchEntity"/>
        /// </summary>
        public int? BranchId { get; set; }

        /// <summary>
        /// The related <see cref="BranchEntity"/>
        /// </summary>
        public BranchEntity Branch { get; set; }

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
        /// <param name="branchId">The branch's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static ImageEntity FromRequestModel(int branchId, ImageRequestModel model) 
            => ControllersHelper.FromRequestModel(model, delegate (ImageEntity entity) { entity.BranchId = branchId; });

        /// <summary>
        /// Creates and returns a <see cref="ImageResponseModel"/> from the current <see cref="ImageEntity"/>
        /// </summary>
        /// <returns></returns>
        public ImageResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<ImageEntity, ImageResponseModel>(this);

        #endregion

    }
}
