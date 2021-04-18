namespace Fooli
{
    /// <summary>
    /// The branch request model
    /// </summary>
    public class BranchRequestModel : BaseRequestModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BranchRequestModel()
        {

        }

        #endregion
    }
}
