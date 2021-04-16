using System;

namespace Fooli
{
    /// <summary>
    /// Represents a leaflet in the database
    /// </summary>
    public class LeafletEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The date from which the leaflet applies
        /// </summary>
        public DateTimeOffset DateStart { get; set; }

        /// <summary>
        /// The date that ends what the leaflet applies
        /// </summary>
        public DateTimeOffset DateEnd { get; set; }

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
        public LeafletEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="LeafletEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static LeafletEntity FromRequestModel(int companyId, LeafletRequestModel model) 
            => ControllersHelper.FromRequestModel(model, (LeafletEntity entity) => { entity.CompanyId = companyId; });

        /// <summary>
        /// Creates and returns a <see cref="LeafletResponseModel"/> from the current <see cref="LeafletEntity"/>
        /// </summary>
        /// <returns></returns>
        public LeafletResponseModel ToResponseModel() 
            => ControllersHelper.ToResponseModel<LeafletEntity, LeafletResponseModel>(this);

        #endregion
    }
}
