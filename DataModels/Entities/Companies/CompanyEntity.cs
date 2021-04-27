using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a company in the database
    /// </summary>
    public class CompanyEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the logo image
        /// </summary>
        public string LogoImageName { get; set; }

        /// <summary>
        /// The logo image's url
        /// </summary>
        public string LogoImageSource { get; set; }

        /// <summary>
        /// The logo image's alternative text
        /// </summary>
        public string LogoImageAlt { get; set; }

        /// <summary>
        /// The name of the text image
        /// </summary>
        public string TextImageName { get; set; }

        /// <summary>
        /// The text image's url
        /// </summary>
        public string TextImageSource { get; set; }

        /// <summary>
        /// The text image's alternative text
        /// </summary>
        public string TextImageAlt { get; set; }

        #region Relationships

        /// <summary>
        /// The companies and products
        /// </summary>
        public IEnumerable<CompanyProductEntity> CompayProducts { get; set; }

        /// <summary>
        /// The company's leaflets
        /// </summary>
        public IEnumerable<LeafletEntity> Leaflets { get; set; }

        /// <summary>
        /// The company's branches
        /// </summary>
        public IEnumerable<BranchEntity> Branches { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyEntity()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CompanyEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CompanyEntity FromRequestModel(CompanyRequestModel model)
            => ControllersHelper.FromRequestModel<CompanyEntity, CompanyRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CompanyResponseModel"/> from the current <see cref="CompanyEntity"/>
        /// </summary>
        /// <returns></returns>
        public CompanyResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<CompanyEntity, CompanyResponseModel>(this);

        #endregion
    }
}
