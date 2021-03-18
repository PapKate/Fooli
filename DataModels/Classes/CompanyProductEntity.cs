namespace Fooli
{
    /// <summary>
    /// Represents a specific company's product
    /// </summary>
    public class CompanyProductEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The <see cref="CompanyEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The <see cref="ProductEntity"/> of the related <see cref="ProductEntity"/>
        /// </summary>
        public int ProductrId { get; set; }

        /// <summary>
        /// The related <see cref="ProductEntity"/>
        /// </summary>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// The product's price
        /// </summary>
        public double Price { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyProductEntity()
        {

        }

        #endregion

    }
}
