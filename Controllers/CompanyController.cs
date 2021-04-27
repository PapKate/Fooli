
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
        protected IQueryable<CompanyEntity> CompaniesQuery => mContext.Companies;
        
        /// <summary>
        /// The query used for retrieving the leaflets
        /// </summary>
        protected IQueryable<LeafletEntity> LeafletsQuery => mContext.Leaflets;

        /// <summary>
        /// The query used for retrieving the images
        /// </summary>
        protected IQueryable<ImageEntity> ImagesQuery => mContext.Images;

        /// <summary>
        /// The query used for retrieving the branches
        /// </summary>
        protected IQueryable<BranchEntity> BranchesQuery => mContext.Branches.Include(x => x.Images);

        /// <summary>
        /// The query used for retrieving the company products
        /// </summary>
        protected IQueryable<CompanyProductEntity> CompanyProductsQuery => mContext.CompanyProducts;

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
            => ControllersHelper.PostAsync(
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
        public Task<ActionResult<CompanyResponseModel>> GetCompanyAsync([FromRoute] int companyId) => ControllersHelper.GetAsync<CompanyEntity, CompanyResponseModel>(
               CompaniesQuery,
               DI.GetMapper,
               x => x.Id == companyId);

        /// <summary>
        /// Updates the data of the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// Put fooli/companies/3
        [HttpPut]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> UpdateCompanyAsync([FromRoute] int companyId, CompanyRequestModel model)
        {
            return ControllersHelper.PutAsync<CompanyRequestModel, CompanyEntity, CompanyResponseModel>(
                mContext,
                CompaniesQuery,
                model,
                x => x.Id == companyId);
        }

        /// <summary>
        /// Deletes the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Delete fooli/companies/3
        [HttpDelete]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> DeleteCompanyAsync([FromRoute] int companyId) => ControllersHelper.DeleteAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
                DI.GetMapper,
                x => x.Id == companyId);

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
        /// Get fooli/companies/1/leaflets/4
        [HttpGet]
        [Route(Routes.CompanyLeafletRoute)]
        public Task<ActionResult<LeafletResponseModel>> GetLeafletAsync([FromRoute] int companyId, [FromRoute] int leafletId)
            => ControllersHelper.GetAsync<LeafletEntity, LeafletResponseModel>(
                LeafletsQuery,
                DI.GetMapper,
                x => x.Id == leafletId && x.CompanyId == companyId);

        /// <summary>
        /// Updates a leaflet with the specified <paramref name="leafletId"/> that belongs to the  company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="leafletId">The leaflet's id</param>
        /// <param name="model">The model</param>
        /// Put fooli/companies/1/leaflets/4
        [HttpPut]
        [Route(Routes.CompanyLeafletRoute)]
        public Task<ActionResult<LeafletResponseModel>> UpdateLeafletAsync([FromRoute] int companyId, [FromRoute] int leafletId, [FromBody] LeafletRequestModel model)
            => ControllersHelper.PutAsync<LeafletRequestModel, LeafletEntity, LeafletResponseModel>(
                mContext,
                LeafletsQuery,
                model,
                x => x.CompanyId == companyId && x.Id == leafletId);

        /// <summary>
        /// Deletes a leaflet with the specified <paramref name="leafletId"/> that belongs to the  company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="leafletId"></param>
        /// Delete fooli/companies/1/leaflets/4
        [HttpDelete]
        [Route(Routes.CompanyLeafletRoute)]
        public Task<ActionResult<LeafletResponseModel>> DeleteLeafletAsync([FromRoute] int companyId, [FromRoute] int leafletId)
            => ControllersHelper.DeleteAsync<LeafletEntity, LeafletResponseModel>(
                mContext,
                LeafletsQuery,
                DI.GetMapper,
                x => x.CompanyId == companyId && x.Id == leafletId);

        #endregion

        #region Branch

        /// <summary>
        /// Creates a branch for the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// fooli/companies/2/branches
        [HttpPost]
        [Route(Routes.CompanyBranchesRoute)]
        public Task<ActionResult<BranchResponseModel>> CreateBranchAsync([FromRoute] int companyId, [FromBody] BranchRequestModel model)
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Branches,
                BranchEntity.FromRequestModel(companyId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the branches of the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get fooli/companies/2/branches/
        [HttpGet]
        [Route(Routes.CompanyBranchesRoute)]
        public Task<ActionResult<IEnumerable<BranchResponseModel>>> GetAllBranchesAsync([FromRoute] int companyId)
            => ControllersHelper.GetAllAsync<BranchEntity, BranchResponseModel>(
                BranchesQuery,
                x => x.CompanyId == companyId);

        /// <summary>
        /// Gets the branch with the specified <paramref name="branchId"/> and <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="branchId">The branch's Id</param>
        /// Get fooli/companies/2/branches/4
        [HttpGet]
        [Route(Routes.CompanyBranchRoute)]
        public Task<ActionResult<BranchResponseModel>> GetBranchAsync([FromRoute] int companyId, [FromRoute] int branchId)
            => ControllersHelper.GetAsync<BranchEntity, BranchResponseModel>(
                BranchesQuery,
                DI.GetMapper,
                x => x.Id == branchId && x.CompanyId == companyId);

        /// <summary>
        /// Updates the branch with the specified <paramref name="branchId"/> and <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="branchId">The branch's id</param>
        /// <param name="model">The model</param>
        /// Put fooli/companies/2/branches/3
        [HttpPut]
        [Route(Routes.CompanyBranchRoute)]
        public Task<ActionResult<BranchResponseModel>> UpdateBranchAsync([FromRoute] int companyId, [FromRoute] int branchId, [FromBody] BranchRequestModel model)
            => ControllersHelper.PutAsync<BranchRequestModel, BranchEntity, BranchResponseModel>(
                mContext,
                BranchesQuery,
                model,
                x => x.Id == branchId && x.CompanyId == companyId);

        /// <summary>
        /// Deletes the branch with the specified <paramref name="branchId"/> and <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="branchId">The branch's id</param>
        /// Delete fooli/companies/2/branches/3
        [HttpDelete]
        [Route(Routes.CompanyBranchRoute)]
        public Task<ActionResult<BranchResponseModel>> DeleteBranchAsync([FromRoute] int companyId, [FromRoute] int branchId)
            => ControllersHelper.DeleteAsync<BranchEntity, BranchResponseModel>(
                mContext,
                BranchesQuery,
                DI.GetMapper,
                x => x.Id == branchId && x.CompanyId == companyId);

        #endregion

        #region Branch Images

        /// <summary>
        /// Creates a new company image
        /// </summary>
        /// <param name="branchId">The branch's id</param>
        /// <param name="model">The model</param>
        /// Post fooli/companies/5/branches/4/images
        [HttpPost]
        [Route(Routes.BranchImagesRoute)]
        public Task<ActionResult<ImageResponseModel>> CreateImageAsync([FromRoute] int branchId, [FromBody] ImageRequestModel model) 
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Images,
                ImageEntity.FromRequestModel(branchId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the images that belong to the company with the specified <paramref name="branchId"/>
        /// </summary>
        /// <param name="branchId">The branch's id</param>
        /// Get fooli/companies/1/branches/4/images
        [HttpGet]
        [Route(Routes.BranchImagesRoute)]
        public Task<ActionResult<IEnumerable<ImageResponseModel>>> GetImagesAsync([FromRoute] int branchId)
            => ControllersHelper.GetAllAsync<ImageEntity, ImageResponseModel>(
                ImagesQuery,
                x => x.BranchId == branchId);

        /// <summary>
        /// Gets the image with the <paramref name="imageId"/> that belongs to the company with the specified <paramref name="branchId"/>
        /// </summary>
        /// <param name="branchId">The branch's id</param>
        /// <param name="imageId">The image's id</param>
        /// Get fooli/companies/1/branches/4/images/5
        [HttpGet]
        [Route(Routes.BranchImageRoute)]
        public Task<ActionResult<ImageResponseModel>> GetImageAsync([FromRoute] int branchId, [FromRoute] int imageId)
            => ControllersHelper.GetAsync<ImageEntity, ImageResponseModel>(
                ImagesQuery,
                DI.GetMapper,
                x => x.Id == imageId && x.BranchId == branchId);

        /// <summary>
        /// Updates an image with the specified <paramref name="imageId"/> that belongs to the  company with the specified <paramref name="branchId"/>
        /// </summary>
        /// <param name="branchId">The branch's id</param>
        /// <param name="imageId">The image's id</param>
        /// <param name="model"></param>
        /// Put fooli/companies/1/branches/4/images/6
        [HttpPut]
        [Route(Routes.BranchImageRoute)]
        public Task<ActionResult<ImageResponseModel>> UpdateImageAsync([FromRoute] int branchId, [FromRoute] int imageId, [FromBody] ImageRequestModel model)
            => ControllersHelper.PutAsync<ImageRequestModel,ImageEntity, ImageResponseModel>(
                mContext,
                ImagesQuery,
                model,
                x => x.BranchId == branchId && x.Id == imageId);

        /// <summary>
        /// Deletes an image with the specified <paramref name="imageId"/> that belongs to the  company with the specified <paramref name="branchId"/>
        /// </summary>
        /// <param name="branchId">The branch's id</param>
        /// <param name="imageId">The image's id</param>
        /// Delete fooli/companies/1/branches/4/images/6
        [HttpDelete]
        [Route(Routes.BranchImageRoute)]
        public Task<ActionResult<ImageResponseModel>> DeleteImageAsync([FromRoute] int branchId, [FromRoute] int imageId)
            => ControllersHelper.DeleteAsync<ImageEntity, ImageResponseModel>(
                mContext,
                ImagesQuery,
                DI.GetMapper,
                x => x.BranchId == branchId && x.Id == imageId);

        #endregion

        #endregion

        #region Company Product

        /// <summary>
        /// Creates a new company product 
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The model</param>
        /// Post fooli/companies/2/companyProducts
        [HttpPost]
        [Route(Routes.CompanyProductsRoute)]
        public Task<ActionResult<CompanyProductResponseModel>> CreateCompanyProductAsync([FromRoute] int companyId, [FromBody] CompanyProductRequestModel model)
        {
            return ControllersHelper.PostAsync(
                           mContext,
                           mContext.CompanyProducts,
                           CompanyProductEntity.FromRequestModel(companyId, model),
                           x => x.ToResponseModel());
        }

        /// <summary>
        /// Gets all the products of the company with the specified <paramref name="companyId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get fooli/companies/3/companyPropducts
        [HttpGet]
        [Route(Routes.CompanyProductsRoute)]
        public Task<ActionResult<IEnumerable<CompanyProductResponseModel>>> GetCompanyProductsAsync([FromRoute] int companyId)
            => ControllersHelper.GetAllAsync<CompanyProductEntity, CompanyProductResponseModel>(
                CompanyProductsQuery,
                x => x.CompanyId == companyId);

        /// <summary>
        /// Gets the product of the company with the specified <paramref name="companyId"/> and <paramref name="companyProductId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="companyProductId"></param>
        /// Get fooli/companies/3/companyPropducts/3
        [HttpGet]
        [Route(Routes.CompanyProductRoute)]
        public Task<ActionResult<CompanyProductResponseModel>> GetCompanyProductAsync([FromRoute] int companyId, [FromRoute] int companyProductId)
            => ControllersHelper.GetAsync<CompanyProductEntity, CompanyProductResponseModel>(
                CompanyProductsQuery,
                DI.GetMapper,
                x => x.CompanyId == companyId && x.Id == companyProductId);

        /// <summary>
        /// Updates the product of the company with the specified <paramref name="companyId"/> and <paramref name="companyProductId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="companyProductId"></param>
        /// <param name="model">The model</param>
        /// Put fooli/companies/3/companyPropducts/3
        [HttpPut]
        [Route(Routes.CompanyProductRoute)]
        public Task<ActionResult<CompanyProductResponseModel>> UpadteCompanyProductAsync([FromRoute] int companyId, [FromRoute] int companyProductId, [FromBody] CompanyProductRequestModel model)
            => ControllersHelper.PutAsync<CompanyProductRequestModel, CompanyProductEntity, CompanyProductResponseModel>(
                mContext,
                CompanyProductsQuery,
                model,
                x => x.CompanyId == companyId && x.Id == companyProductId);

        /// <summary>
        /// Deletes the product of the company with the specified <paramref name="companyId"/> and <paramref name="companyProductId"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="companyProductId"></param>
        /// <param name="model">The model</param>
        /// Delete fooli/companies/3/companyPropducts/3
        [HttpDelete]
        [Route(Routes.CompanyProductRoute)]
        public Task<ActionResult<CompanyProductResponseModel>> DeleteCompanyProductAsync([FromRoute] int companyId, [FromRoute] int companyProductId)
            => ControllersHelper.DeleteAsync<CompanyProductEntity, CompanyProductResponseModel>(
                mContext,
                CompanyProductsQuery,
                DI.GetMapper,
                x => x.CompanyId == companyId && x.Id == companyProductId);

        #endregion

    }
}
