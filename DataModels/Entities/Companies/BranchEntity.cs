using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// The branch entity
    /// </summary>
    public class BranchEntity : BaseEntity
    {
        #region Public Properties

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
        public string PostalCode { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="BranchEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static BranchEntity FromRequestModel(int companyId, BranchRequestModel model)
            => ControllersHelper.FromRequestModel(model, (BranchEntity entity) => { entity.CompanyId = companyId});

        /// <summary>
        /// Creates and returns a <see cref="BranchResponseModel"/> from the current <see cref="BranchEntity"/>
        /// </summary>
        /// <returns></returns>
        public BranchResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<BranchEntity, BranchResponseModel>(this);

        #endregion
    }
}
