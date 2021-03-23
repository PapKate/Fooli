namespace Fooli
{
    public class CompanyRequestModel
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
        public int? PostalCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyRequestModel()
        {

        }

        #endregion
    }
}
