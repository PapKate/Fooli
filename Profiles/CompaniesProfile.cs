using AutoMapper;

namespace Fooli
{
    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per
    /// profile.
    /// </summary>
    public class CompaniesProfile : Profile
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompaniesProfile()
        {
            // Creates an auto mapper that maps the database's companies table to the company response model
            CreateMap<CompanyEntity, CompanyResponseModel>();

            // Creates an auto mapper that maps the company request model to the database's companies table
            CreateMap<CompanyRequestModel, CompanyEntity>();
        }

        #endregion

    }
}
