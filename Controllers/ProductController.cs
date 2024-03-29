﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// The product's controller
    /// </summary>
    public class ProductController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly FooliDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the products
        /// </summary>
        protected IQueryable<ProductEntity> ProductsQuery => mContext.Products.Include(x => x.Images)
                                                                              .Include(x => x.CompaniesProducts).ThenInclude(x => x.Company)
                                                                              .Include(x => x.ProductLabels).ThenInclude(x => x.Label)
                                                                              .Include(x => x.ProductCategories).ThenInclude(x => x.Category);

        

        /// <summary>
        /// The query used for retrieving the images
        /// </summary>
        protected IQueryable<ImageEntity> ImagesQuery => mContext.Images;

        /// <summary>
        /// The query used for retrieving the categories
        /// </summary>
        protected IQueryable<CategoryEntity> CategoriesQuery => mContext.Categories.Include(x => x.ChildrenCategories)
                                                                                   .Include(x => x.ProductCategories);

        /// <summary>
        /// The query used for retrieving the labels
        /// </summary>
        protected IQueryable<LabelEntity> LabelsQuery => mContext.Labels;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductController(FooliDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        #region Products

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="model">The model</param>
        /// fooli/products
        [HttpPost]
        [Route(Routes.ProductsRoute)]
        public Task<ActionResult<ProductResponseModel>> CreateProductAsync([FromBody] ProductRequestModel model)
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Products,
                ProductEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the products
        /// </summary>
        /// Get fooli/products
        [HttpGet]
        [Route(Routes.ProductsRoute)]
        public Task<ActionResult<IEnumerable<ProductResponseModel>>> GetAllProductsAsync()
            => ControllersHelper.GetAllAsync<ProductEntity, ProductResponseModel>(
                ProductsQuery,
                x => true);

        /// <summary>
        /// Gets the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// Get fooli/products/8
        [HttpGet]
        [Route(Routes.ProductRoute)]
        public Task<ActionResult<ProductResponseModel>> GetProductAsync([FromRoute] int productId)
            => ControllersHelper.GetAsync<ProductEntity, ProductResponseModel>(
                ProductsQuery,
                DI.GetMapper,
                x => x.Id == productId);

        /// <summary>
        /// Updates the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="model"></param>
        /// Put fooli/products/7
        [HttpPut]
        [Route(Routes.ProductRoute)]
        public Task<ActionResult<ProductResponseModel>> UpdateProductAsync([FromRoute] int productId, [FromBody] ProductRequestModel model)
            => ControllersHelper.PutAsync<ProductRequestModel, ProductEntity, ProductResponseModel>(
                mContext,
                ProductsQuery,
                model,
                x => x.Id == productId);

        /// <summary>
        /// Deletes the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// Delete fooli/products/7
        [HttpDelete]
        [Route(Routes.ProductRoute)]
        public Task<ActionResult<ProductResponseModel>> DeleteProductAsync([FromRoute] int productId)
            => ControllersHelper.DeleteAsync<ProductEntity, ProductResponseModel>(
                mContext,
                ProductsQuery,
                DI.GetMapper,
                x => x.Id == productId);

        #endregion

        #region Product Images

        /// <summary>
        /// Creates a new product image
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="model">The model</param>
        /// Get fooli/products/1/images
        [HttpPost]
        [Route(Routes.ProductImagesRoute)]
        public Task<ActionResult<ImageResponseModel>> CreateProductImageAsync([FromRoute] int productId, [FromBody] ImageRequestModel model)
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Images,
                ImageEntity.FromRequestModel(productId, model),
                x=> x.ToResponseModel());

        /// <summary>
        /// Gets all the images that belong to the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// Get fooli/products/1/images
        [HttpGet]
        [Route(Routes.ProductImagesRoute)]
        public Task<ActionResult<IEnumerable<ImageResponseModel>>> GetImagesAsync([FromRoute] int productId)
            => ControllersHelper.GetAllAsync<ImageEntity, ImageResponseModel>(
                ImagesQuery,
                x => x.ProductId == productId);

        /// <summary>
        /// Gets the image with the <paramref name="imageId"/> that belongs to the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="imageId">The image's id</param>
        /// Get fooli/products/1/images/5
        [HttpGet]
        [Route(Routes.ProductImageRoute)]
        public Task<ActionResult<ImageResponseModel>> GetImageAsync([FromRoute] int productId, [FromRoute] int imageId)
            => ControllersHelper.GetAsync<ImageEntity, ImageResponseModel>(
                ImagesQuery,
                DI.GetMapper,
                x => x.Id == imageId && x.ProductId == productId);

        /// <summary>
        /// Updates an image with the specified <paramref name="imageId"/> that belongs to the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="imageId">The image's id</param>
        /// <param name="model"></param>
        /// Put fooli/products/1/images/6
        [HttpPut]
        [Route(Routes.ProductImageRoute)]
        public Task<ActionResult<ImageResponseModel>> UpdateImageAsync([FromRoute] int productId, [FromRoute] int imageId, [FromBody] ImageRequestModel model)
            => ControllersHelper.PutAsync<ImageRequestModel, ImageEntity, ImageResponseModel>(
                mContext,
                ImagesQuery,
                model,
                x => x.ProductId == productId && x.Id == imageId);

        /// <summary>
        /// Deletes an image with the specified <paramref name="imageId"/> that belongs to the product with the specified <paramref name="productId"/>
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="imageId">The image's id</param>
        /// Delete fooli/products/1/images/6
        [HttpDelete]
        [Route(Routes.ProductImageRoute)]
        public Task<ActionResult<ImageResponseModel>> DeleteImageAsync([FromRoute] int productId, [FromRoute] int imageId)
            => ControllersHelper.DeleteAsync<ImageEntity, ImageResponseModel>(
                mContext,
                ImagesQuery,
                DI.GetMapper,
                x => x.ProductId == productId && x.Id == imageId);

        #endregion

        #region Categories

        /// <summary>
        /// Creates a new Category
        /// </summary>
        /// <param name="model">The model</param>
        /// fooli/categories
        [HttpPost]
        [Route(Routes.CategoriesRoute)]
        public Task<ActionResult<CategoryResponseModel>> CreateCategoryAsync([FromBody] CategoryRequestModel model)
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Categories,
                CategoryEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the categories
        /// </summary>
        /// fooli/categories
        [HttpGet]
        [Route(Routes.ProductCategoriesRoute)]
        public Task<ActionResult<IEnumerable<CategoryResponseModel>>> GetCategoriesAsync() 
            => ControllersHelper.GetAllAsync<CategoryEntity, CategoryResponseModel>(
                CategoriesQuery,
                x => true);

        /// <summary>
        /// Gets the <see cref="CategoryResponseModel"/> with the specified <paramref name="categoryId"/>
        /// </summary>
        /// <param name="categoryId">The category's id</param>
        /// Get fooli/categories/7
        [HttpGet]
        [Route(Routes.CategoryRoute)]
        public Task<ActionResult<CategoryResponseModel>> GetCategoryAsync([FromRoute] int categoryId)
            => ControllersHelper.GetAsync<CategoryEntity, CategoryResponseModel>(
                CategoriesQuery,
                DI.GetMapper,
                x=> x.Id == categoryId);

        /// <summary>
        /// Updates the <see cref="CategoryEntity"/> with the specified <paramref name="categoryId"/>
        /// </summary>
        /// <param name="categoryId">The category's id</param>
        /// <param name="model">The model</param>
        /// Put fooli/categories/8
        [HttpDelete]
        [Route(Routes.CategoryRoute)]
        public Task<ActionResult<CategoryResponseModel>> UpdateCategoryAsync([FromRoute] int categoryId, [FromBody] CategoryRequestModel model)
        => ControllersHelper.PutAsync<CategoryRequestModel, CategoryEntity, CategoryResponseModel>(
            mContext,
            CategoriesQuery,
            model,
            x => x.Id == categoryId);

        /// <summary>
        /// Deletes the <see cref="CategoryEntity"/> with the specified <paramref name="categoryId"/>
        /// </summary>
        /// <param name="categoryId"></param>
        /// Delete fooli/categories/8
        [HttpDelete]
        [Route(Routes.CategoryRoute)]
        public Task<ActionResult<CategoryResponseModel>> DeleteCategoryAsync([FromRoute] int categoryId)
        => ControllersHelper.DeleteAsync<CategoryEntity, CategoryResponseModel>(
            mContext,
            CategoriesQuery,
            DI.GetMapper,
            x => x.Id == categoryId);

        #endregion

        #region Labels

        /// <summary>
        /// Creates a new label
        /// </summary>
        /// <param name="model">The model</param>
        /// fooli/labels
        [HttpPost]
        [Route(Routes.LabelsRoute)]
        public Task<ActionResult<LabelResponseModel>> CreateLabelAsync([FromBody] LabelRequestModel model)
            => ControllersHelper.PostAsync(
                mContext,
                mContext.Labels,
                LabelEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the labels
        /// </summary>
        /// fooli/labels
        [HttpGet]
        [Route(Routes.LabelsRoute)]
        public Task<ActionResult<IEnumerable<LabelResponseModel>>> GetLabels()
            => ControllersHelper.GetAllAsync<LabelEntity, LabelResponseModel>(
                LabelsQuery,
                x => true);

        /// <summary>
        /// Gets the <see cref="LabelResponseModel"/> with the specified <paramref name="labelId"/>
        /// </summary>
        /// <param name="labelId">The label's id </param>
        /// fooli/labels/4
        [HttpGet]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> GetLabel([FromRoute] int labelId) 
            => ControllersHelper.GetAsync<LabelEntity, LabelResponseModel>(
                LabelsQuery,
                DI.GetMapper,
                x => x.Id == labelId);

        /// <summary>
        /// Updates the label with the specified <paramref name="labelId"/>
        /// </summary>
        /// <param name="labelId">The id</param>
        /// <param name="model">The model</param>
        /// Put fooli/labels/3
        [HttpPut]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> UpdateLabel([FromRoute] int labelId, [FromBody] LabelRequestModel model)
            => ControllersHelper.PutAsync<LabelRequestModel, LabelEntity, LabelResponseModel>(
                mContext,
                LabelsQuery,
                model,
                x => x.Id == labelId);

        /// <summary>
        /// Deletes the label with the specified <paramref name="labelId"/>
        /// </summary>
        /// <param name="labelId">The id</param>
        /// Delete fooli/labels/4
        [HttpDelete]
        [Route(Routes.LabelRoute)]
        public Task<ActionResult<LabelResponseModel>> DeleteLabel([FromRoute] int labelId)
            => ControllersHelper.DeleteAsync<LabelEntity, LabelResponseModel>(
                mContext,
                LabelsQuery,
                DI.GetMapper,
                x => x.Id == labelId);


        #endregion

        #endregion

    }
}
