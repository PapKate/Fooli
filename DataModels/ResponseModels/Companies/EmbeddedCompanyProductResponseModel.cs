namespace Fooli
{
    /// <summary>
    /// The embedded version of a company product entity
    /// </summary>
    public class EmbeddedCompanyProductResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The quantity
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// The abbreviation
        /// ex. TM, kg, gr
        /// </summary>
        public string Αbbreviation { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Shows if product is on sale
        /// </summary>
        public bool IsOnSale { get; set; }

        /// <summary>
        /// The product is verified by the company
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// The <see cref="BaseResponseModel.Id"/> of the related <see cref="EmbeddedCompanyResponseModel"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedCompanyResponseModel"/>
        /// </summary>
        public EmbeddedCompanyResponseModel Company { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedCompanyProductResponseModel()
        {

        }

        #endregion
    }
}
