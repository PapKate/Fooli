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
    public class ListsProfile : Profile
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListsProfile()
        {
            // Source -> Target
            // Creates an auto mapper that maps the database's list table to the list get response model
            CreateMap<ListEntity, ListResponseModel>();

            // Creates an auto mapper that maps the list create request model to the database's list table
            CreateMap<ListRequestModel, ListEntity>();
        }

        #endregion

    }
}
