using System.Collections.Generic;

namespace Fooli
{
    /// <summary>
    /// Represents a company in the database
    /// </summary>
    public class CompanyEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

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
        public int PhoneNumber { get; set; }

        /// <summary>
        /// The postal code
        /// </summary>
        public int PostalCode { get; set; }

        #region Relationships

        /// <summary>
        /// The companies and products
        /// </summary>
        public IEnumerable<CompanyProductEntity> CompaniesProducts { get; set; }

        /// <summary>
        /// The company's leaflets
        /// </summary>
        public IEnumerable<LeafletEntity> Leaflets { get; set; }

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
    }
}
