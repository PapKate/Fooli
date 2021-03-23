using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Provides a named configuration for maps. Naming conventions become scoped per
    /// profile.
    /// </summary>
    public class ImagesProfile : Profile
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImagesProfile()
        {
            // Creates an auto mapper the maps the image entity to an image response model
            CreateMap<ImageEntity, ImageResponseModel>();


            // Creates an auto mapper that maps the image request model to an image entity
            CreateMap<ImageRequestModel, ImageEntity>();
        }

        #endregion

    }
}
