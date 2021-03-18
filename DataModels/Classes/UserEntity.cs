﻿namespace Fooli
{
    /// <summary>
    /// Represents a user in the database
    /// </summary>
    public class UserEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The profile's picture url
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        public string FisrtName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The first-main address
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The secondary address
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The postal code
        /// </summary>
        public int? PostalCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserEntity()
        {

        }

        #endregion

    }
}