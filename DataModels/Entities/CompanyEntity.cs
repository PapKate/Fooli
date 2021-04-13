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
        /// The country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The postal code
        /// </summary>
        public int PostalCode { get; set; }

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
        /// The company's images
        /// </summary>
        public IEnumerable<ImageEntity> Images { get; set; }

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
