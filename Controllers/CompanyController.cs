
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Api companies
    /// </summary>
    public class CompanyController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly FooliDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the companies
        /// </summary>
        protected IQueryable<CompanyEntity> CompaniesQuery => mContext.Companies.Include(x => x.Images)
                                                                                .Include(x => x.Leaflets);
        
        /// <summary>
        /// The query used for retrieving the leaflets
        /// </summary>
        protected IQueryable<LeafletEntity> LeafletsQuery => mContext.Leaflets.Include(x => x.Company);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyController(FooliDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        #region Companies

        /// <summary>
        /// Creates a new company
        /// </summary>
        /// <param name="model">The company request model</param>
        /// Post fooli/companies
        [HttpPost]
        [Route(Routes.CompaniesRoute)]
        public Task<ActionResult<CompanyResponseModel>> CreateCompanyAsync([FromBody] CompanyRequestModel model)
            => ControllersHelper.PostAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
                CompanyEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the companies
        /// </summary>
        /// Get fooli/companies
        [HttpGet]
        [Route(Routes.CompaniesRoute)]
        public Task<ActionResult<IEnumerable<CompanyResponseModel>>> GetCompaniesAsync() => ControllersHelper.GetAllAsync<CompanyEntity, CompanyResponseModel>(
                CompaniesQuery,
                x => true);

        /// <summary>
        /// Gets the company with the specified id
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get fooli/companies/2
        [HttpGet]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> GetCompany([FromRoute] int companyId) => ControllersHelper.GetAsync<CompanyRequestModel, CompanyEntity, CompanyResponseModel>(
               CompaniesQuery,
               DI.GetMapper,
               x => x.Id == companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<CompanyResponseModel>> UpdateCompany([FromRoute] int companyId, CompanyRequestModel model)
        {
            // Gets the company from the database with the specified id
            var company = await mContext.Companies.Include(x => x.CompayProducts)
                                            .Include(x => x.Leaflets)
                                            .Include(x => x.Images)
                                            .FirstOrDefaultAsync(x => x.Id == companyId);

            // If a company is NOT found...
            if (company == null)
                // If no company is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
                // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
                // response.
                return NotFound();

            // If the model has a name...
            if (model.Name != null)
                // Sets the company's name equal to the model's
                company.Name = model.Name;

            // If the model has a country...
            if (model.Country != null)
                // Sets the company's country equal to the model's
                company.Country = model.Country;

            // If the model has a City...
            if (model.City != null)
                // Sets the company's City equal to the model's
                company.City = model.City;

            // If the model has an address...
            if (model.Address != null)
                // Sets the company's Address equal to the model's
                company.Address = model.Address;

            // If the model has a PhoneNumber...
            if (model.PhoneNumber != null)
                // Sets the company's PhoneNumber equal to the model's
                company.PhoneNumber = model.PhoneNumber;

            // If the model has a PostalCode...
            if (model.PostalCode != null)
                // Sets the company's PostalCode equal to the model's
                company.PostalCode = (int)model.PostalCode;

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            // Returns a map note response model from the entity
            return DI.GetMapper.Map<CompanyResponseModel>(company);
        }

        /// <summary>
        /// Deletes the company with the specified id
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Delete fooli/companies/3
        [HttpDelete]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> DeleteCompany([FromRoute] int companyId)
        {
            return ControllersHelper.DeleteAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
                DI.GetMapper,
                x => x.Id == companyId);
        }

        #endregion

        #region Leaflets

        /// <summary>
        /// Creates a new leaflet
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// Post fooli/companies/5/leaflets
        [HttpPost]
        [Route(Routes.CompanyLeafletsRoute)]
        public Task<ActionResult<LeafletResponseModel>> CreateLeafletAsync([FromRoute] int companyId, [FromBody] LeafletRequestModel model) => ControllersHelper.PostAsync<LeafletEntity, LeafletResponseModel>(
                mContext,
                mContext.Leaflets,
                LeafletEntity.FromRequestModel(companyId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the leaflets that belong to the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get fooli/companies/1/leaflets
        [HttpGet]
        [Route(Routes.CompanyLeafletsRoute)]
        public Task<ActionResult<IEnumerable<LeafletResponseModel>>> GetLeafletsAsync([FromRoute] int companyId)
            => ControllersHelper.GetAllAsync<LeafletEntity, LeafletResponseModel>(
                LeafletsQuery,
                x => x.CompanyId == companyId);

        /// <summary>
        /// Gets the leaflet with the <paramref name="leafletId"/> that belongs to the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="leafletId">The leaflet's id</param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.CompanyLeafletRoute)]
        public Task<ActionResult<LeafletResponseModel>> GetLeafletAsync([FromRoute] int companyId, [FromRoute] int leafletId)
            => ControllersHelper.GetAsync<LeafletRequestModel,LeafletEntity, LeafletResponseModel>(
                LeafletsQuery,
                DI.GetMapper,
                x => x.Id == leafletId && x.CompanyId == companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="leafletId"></param>
        /// <returns></returns>
        public Task<ActionResult<LeafletResponseModel>> DeleteLeafletAsync([FromRoute] int companyId, [FromRoute] int leafletId)
            => ControllersHelper.DeleteAsync<LeafletEntity, LeafletResponseModel>(
                mContext,
                LeafletsQuery,
                DI.GetMapper,
                x => x.CompanyId == companyId && x.Id == leafletId);

        #endregion

        #endregion
    }
}
