namespace Fooli
{
    /// <summary>
    /// The branch response model
    /// </summary>
    public class BranchResponseModel : BaseResponseModel
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

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchResponseModel()
        {

        }

        #endregion
    }
}
