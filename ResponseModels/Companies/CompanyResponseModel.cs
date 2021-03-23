using System;
using System.Collections.Generic;

namespace Fooli
{
    public class CompanyResponseModel
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
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The postal code
        /// </summary>
        public int PostalCode { get; set; }

        /// <summary>
        /// The date it was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the image was last modified
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// The companies and products
        /// </summary>
        public IEnumerable<CompanyProductEntity> CompaniesProducts { get; set; }

        /// <summary>
        /// The company's leaflets
        /// </summary>
        public IEnumerable<LeafletEntity> Leaflets { get; set; }

        /// <summary>
        /// The company's images
        /// </summary>
        public IEnumerable<ImageEntity> Images { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyResponseModel()
        {

        }

        #endregion
    }
}
