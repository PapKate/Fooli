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
    public class NoteConstroller : Controller
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
        public NoteConstroller(FooliDBContext context, IMapper mapper)
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
        [Route(Routes.UserNotesRoute)]
        public async Task<ActionResult<NoteResponseModel>> CreateListAsync([FromRoute] int userId,[FromBody] NoteRequestModel model)
        {
            // Maps a list from the request model and creates it
            var note = mMapper.Map<NoteEntity>(model);

            // Sets the date created to now
            note.DateCreated = DateTimeOffset.Now;
            // Sets the date it was last modified to now
            note.DateModified = DateTimeOffset.Now;

            note.UserId = userId;

            note.CheckListItems.ToList().ForEach(x => x.DateCreated = DateTimeOffset.Now);
            note.CheckListItems.ToList().ForEach(x => x.DateModified = DateTimeOffset.Now);

            // Adds the list to the lists in memory
            mContext.Notes.Add(note);

            // Saves the changes in the database
            await mContext.SaveChangesAsync();

            // Maps the entity to the response model
            var noteResponseModel = mMapper.Map<NoteResponseModel>(note);

            // Returns the response model
            return noteResponseModel;
        }

        /// <summary>
        /// Gets all the lists from the database
        /// </summary>
        /// Get fooli/lists
        [HttpGet]
        [Route(Routes.NotesRoute)]
        public async Task<ActionResult<IEnumerable<NoteResponseModel>>> GetListsAsync()
        {
            var notes = await mContext.Notes.Include(x => x.CheckListItems).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the lists
            return Ok(mMapper.Map<IEnumerable<NoteResponseModel>>(notes));
        }

        /// <summary>
        /// Gets all the lists from the database that belong to the user with the specified id
        /// </summary>
        /// Get fooli/users/{id}/lists
        [HttpGet]
        [Route(Routes.UserNotesRoute)]
        public async Task<ActionResult<IEnumerable<NoteResponseModel>>> GetListsAsync([FromRoute]int userId)
        {
            // Gets all the lists of the user with the specified id to a list
            var notes = await mContext.Notes.Include(x => x.CheckListItems).Where(x => x.UserId == userId).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the lists
            return Ok(mMapper.Map<IEnumerable<NoteResponseModel>>(notes));
        }

        /// <summary>
        /// Gets the list with the specified id
        /// </summary>
        /// <param name="noteId">The specified id</param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.UserNoteRoute)]
        public async Task<ActionResult<NoteResponseModel>> GetListAsync([FromRoute]int userId, [FromRoute]int noteId)
        {
            // Gets the first list with id the specified id from the database
            var note = await mContext.Notes.Include(x => x.CheckListItems).FirstOrDefaultAsync(x => x.Id == noteId && x.UserId == userId);

            // If a list is found
            if(note != null)
                // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
                // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
                // response with the list
                return Ok(mMapper.Map<NoteResponseModel>(note));

            // If no user is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
            // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
            // response.
            return NotFound();
        }

        /// <summary>
        /// Updates the list with the specified id
        /// </summary>
        /// <param name="noteId">The id</param>
        /// <param name="model">The list request model</param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.UserNoteRoute)]
        public async Task<ActionResult<NoteResponseModel>> UpdateListAsync([FromRoute] int userId, [FromRoute] int noteId, [FromBody] NoteRequestModel model)
        {
            // Gets the list with the specified id from the database if exists
            var note = await mContext.Notes.Include(x => x.CheckListItems).FirstOrDefaultAsync(x => x.Id == noteId);

            // If no list is found...
            if (note == null)
                // Return is not found
                return NotFound();

            // If the model has a color...
            if (model.Color != null)
                // Set the list's color equal to the model's
                note.Color = model.Color;

            // If the model has a Title...
            if (model.Title != null)
                // Set the list's Title equal to the model's
                note.Title = model.Title;
            
            // If the model has list items...
            if (model.CheckListItems != null)
            {
                // Creates a new list of item entities
                var newCheckListItemEntities = new List<CheckListItemEntity>();
                // For each item of the model it map them to an entity and adds that entity to the new list
                model.CheckListItems.ToList().ForEach(x => newCheckListItemEntities.Add(mMapper.Map<CheckListItemEntity>(x)));

                // Removes from the context the old items
                mContext.CheckListItems.RemoveRange(note.CheckListItems);
                // Adds to the context the new items
                mContext.CheckListItems.AddRange(newCheckListItemEntities);

                // Set the list's items equal to the model's
                note.CheckListItems = newCheckListItemEntities;
                // For each note sets the date the were last modified to now
                note.CheckListItems.ToList().ForEach(x => x.DateModified = DateTimeOffset.Now);
            }

            // Sets the date it was last modified to now
            note.DateModified = DateTimeOffset.Now;

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            // Returns a map note response model from the note entity
            return mMapper.Map<NoteResponseModel>(note);
        }

        /// <summary>
        /// Deletes the note with the specified noteId and userId
        /// </summary>
        /// Delete /fooli/users/{userId}/notes/{noteId}
        [HttpDelete]
        [Route(Routes.UserNoteRoute)]
        public async Task<ActionResult<NoteResponseModel>> DeleteNote([FromRoute] int userId, [FromRoute] int noteId)
        {
            // Gets the note with id the note id and user id the specified user id if exists
            var note = await mContext.Notes.FirstOrDefaultAsync(x => x.Id == noteId && x.UserId == userId);

            // If no note is found...
            if (note == null)
                // Returns not found
                return NotFound();

            // Removes the note from the context
            mContext.Notes.Remove(note);

            // Save the changes to the database
            await mContext.SaveChangesAsync();

            // Returns the deleted note's response model
            return mMapper.Map<NoteResponseModel>(note);
        }

        #endregion
    }
}
