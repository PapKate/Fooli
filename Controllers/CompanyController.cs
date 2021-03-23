using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
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

        /// <summary>
        /// The auto mapper
        /// </summary>
        private readonly IMapper mMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyController(FooliDBContext context, IMapper mapper)
        {
            mContext = context;

            mMapper = mapper;
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
        public async Task<ActionResult<CompanyResponseModel>> CreateCompanyAsync([FromBody] CompanyRequestModel model)
        {
            // Maps a company request model to a company entity and creates it
            var company = mMapper.Map<CompanyEntity>(model);

            company.DateCreated = DateTimeOffset.Now;
            company.DateModified = DateTimeOffset.Now;

            // Adds the company to the context
            mContext.Companies.Add(company);

            // Save the changes in the database
            await mContext.SaveChangesAsync();

            // Maps the entity to the response model
            var companyResponseModel = mMapper.Map<CompanyResponseModel>(company);

            // Returns the response model
            return companyResponseModel;
        }

        /// <summary>
        /// Gets all the companies
        /// </summary>
        /// Get fooli/companies
        [HttpGet]
        [Route(Routes.CompaniesRoute)]
        public async Task<ActionResult<IEnumerable<CompanyResponseModel>>> GetCompaniesAsync()
        {
            // Gets all the companies from the database
            var companies = await mContext.Companies.Include(x => x.CompaniesProducts)
                                                    .Include(x => x.Leaflets)
                                                    .Include(x => x.Images)
                                                    .ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the companies
            return Ok(mMapper.Map<IEnumerable<CompanyResponseModel>>(companies));
        }

        /// <summary>
        /// Gets the company with the specified id
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get fooli/companies/2
        [HttpGet]
        [Route(Routes.CompanyRoute)]
        public async Task<ActionResult<CompanyResponseModel>> GetCompany([FromRoute] int companyId)
        {
            // Gets the company from the database with the specified id
            var company = await mContext.Companies.Include(x => x.CompaniesProducts)
                                            .Include(x => x.Leaflets)
                                            .Include(x => x.Images)
                                            .FirstOrDefaultAsync(x => x.Id == companyId);

            // If a company is found...
            if (company != null)
                // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
                // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
                // response with the company
                return Ok(mMapper.Map<CompanyResponseModel>(company));

            // If no company is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
            // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
            // response.
            return NotFound();
        }

        public async Task<ActionResult<CompanyResponseModel>> UpdateCompany([FromRoute] int companyId, CompanyRequestModel model)
        {
            // Gets the company from the database with the specified id
            var company = await mContext.Companies.Include(x => x.CompaniesProducts)
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
            return mMapper.Map<CompanyResponseModel>(company);
        }

        /// <summary>
        /// Deletes the company with the specified id
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Delete fooli/companies/3
        [HttpDelete]
        [Route(Routes.CompanyRoute)]
        public async Task<ActionResult<CompanyResponseModel>> DeleteCompany([FromRoute] int companyId)
        {
            // Gets the company from the database with the specified id
            var company = await mContext.Companies.Include(x => x.CompaniesProducts)
                                            .Include(x => x.Leaflets)
                                            .Include(x => x.Images)
                                            .FirstOrDefaultAsync(x => x.Id == companyId);

            // If a company is NOT found...
            if (company == null)
                // If no company is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
                // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
                // response.
                return NotFound();

            mContext.Companies.Remove(company);

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            return mMapper.Map<CompanyResponseModel>(company);
        }

        #endregion

        #region Leaflets

        public async Task<ActionResult<IEnumerable<LeafletResponseModel>>> GetLeafletsAsync()
        {

        }

        #endregion

        #region CompanyProducts

        #endregion

        #endregion
    }
}
