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
    public class NotesProfile : Profile
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotesProfile()
        {
            // Source -> Target

            #region Notes

            // Creates an auto mapper that maps the database's list table to the list get response model
            CreateMap<NoteEntity, NoteResponseModel>();

            // Creates an auto mapper that maps the list create request model to the database's list table
            CreateMap<NoteRequestModel, NoteEntity>();

            #endregion

            #region CheckListItems

            CreateMap<CheckListItemEntity, CheckListItemResponseModel>();

            CreateMap<CheckListItemRequestModel, CheckListItemEntity>();

            #endregion

        }

        #endregion

    }
}
