using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
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
                                                                              .Include(x => x.CompaniesProducts)
                                                                              .Include(x => x.ProductLabels)
                                                                              .Include(x => x.ProductsCategories);

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


        #endregion

        #region Product Images

        #endregion

        #region Product Categories

        #endregion

        #region Product Labels

        #endregion

        #endregion

    }
}
