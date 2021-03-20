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
    /// Api lists
    /// </summary>
    public class ListConstroller : Controller
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
        public ListConstroller(FooliDBContext context, IMapper mapper)
        {
            mContext = context;

            mMapper = mapper;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new list
        /// </summary>
        /// <param name="model">The list request model</param>
        /// Post fooli/lists
        [HttpPost]
        [Route(Routes.ListsRoute)]
        public async Task<ActionResult<ListResponseModel>> CreateListAsync([FromBody] ListRequestModel model)
        {
            // Maps a list from the request model and creates it
            var list = mMapper.Map<ListEntity>(model);

            // Sets the date created to now
            list.DateCreated = DateTimeOffset.Now;
            // Sets the date it was last modified to now
            list.DateModified = DateTimeOffset.Now;

            // Adds the list items to the list items in memory
            mContext.ListItems.AddRange(list.ListItems);
            // Adds the list to the lists in memory
            mContext.Lists.Add(list);

            // Saves the changes in the database
            await mContext.SaveChangesAsync();

            // Maps the entity to the response model
            var listResponseModel = mMapper.Map<ListResponseModel>(list);

            // Returns the response model
            return listResponseModel;
        }

        /// <summary>
        /// Gets all the lists from the database
        /// </summary>
        /// Get fooli/lists
        [HttpGet]
        [Route(Routes.ListsRoute)]
        public async Task<ActionResult<IEnumerable<ListResponseModel>>> GetListsAsync()
        {
            var lists = await mContext.Lists.ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the lists
            return Ok(mMapper.Map<IEnumerable<ListResponseModel>>(lists));
        }

        /// <summary>
        /// Gets all the lists from the database that belong to the user with the specified id
        /// </summary>
        /// Get fooli/users/{id}/lists
        [HttpGet]
        [Route(Routes.ListsRoute)]
        public async Task<ActionResult<IEnumerable<ListResponseModel>>> GetListsAsync([FromRoute]int userId)
        {
            // Gets all the lists of the user with the specified id to a list
            var lists = await mContext.Lists.Where(x => x.UserId == userId).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the lists
            return Ok(mMapper.Map<IEnumerable<ListResponseModel>>(lists));
        }

        /// <summary>
        /// Gets the list with the specified id
        /// </summary>
        /// <param name="id">The specified id</param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.ListRoute)]
        public async Task<ActionResult<ListResponseModel>> GetListAsync([FromRoute]int id)
        {
            // Gets the first list with id the specified id from the database
            var list = await mContext.Lists.FirstOrDefaultAsync(x => x.Id == id);

            // If a list is found
            if(list != null)
                // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
                // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
                // response with the list
                return Ok(mMapper.Map<ListResponseModel>(list));

            // If no user is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
            // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
            // response.
            return NotFound();
        }

        /// <summary>
        /// Updates the list with the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="model">The list request model</param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.ListRoute)]
        public async Task<ActionResult<ListResponseModel>> UpdateListAsync([FromRoute] int id, [FromBody] ListRequestModel model)
        {
            // Gets the list with the specified id from the database if exists
            var list = await mContext.Lists.FirstOrDefaultAsync(x => x.Id == id);

            // If no list is found...
            if (list == null)
                // Return is not found
                return NotFound();

            // If the model has a color...
            if (model.Color != null)
                // Set the list's color equal to the model's
                list.Color = model.Color;

            // If the model has a Title...
            if (model.Title != null)
                // Set the list's Title equal to the model's
                list.Title = model.Title;
            
            // If the model has list items...
            if (model.ListItems != null)
                // Set the list's items equal to the model's
                list.ListItems = model.ListItems;

            list.DateModified = DateTimeOffset.Now;

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            return mMapper.Map<ListResponseModel>(list);
        }

        #endregion
    }
}
