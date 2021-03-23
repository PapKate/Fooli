using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Api images
    /// </summary>
    public class ImageController : Controller
    {
        #region Private Members

        private readonly FooliDBContext mContext;

        private readonly IMapper mMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImageController(IMapper mapper, FooliDBContext context)
        {
            mContext = context;

            mMapper = mapper;
        }

        #endregion

        #region Public Methods



        #endregion

    }
}
