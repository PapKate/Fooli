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
    /// Api notes and check lists items
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

        #region Notes

        /// <summary>
        /// Creates a new list
        /// </summary>
        /// <param name="model">The list request model</param>
        /// Post fooli/lists
        [HttpPost]
        [Route(Routes.UserNotesRoute)]
        public Task<ActionResult<NoteResponseModel>> CreateNoteAsync([FromRoute] int userId, [FromBody] NoteRequestModel model) 
            => ControllersHelper.PostAsync<NoteRequestModel, NoteEntity, NoteResponseModel>(mContext, mContext.Notes, mMapper, model, (entity) => entity.UserId = userId);

        /// <summary>
        /// Gets all the lists from the database that belong to the user with the specified id
        /// </summary>
        /// Get fooli/users/{id}/lists
        [HttpGet]
        [Route(Routes.UserNotesRoute)]
        public async Task<ActionResult<IEnumerable<NoteResponseModel>>> GetNotesAsync([FromRoute]int userId)
        {
            //// Gets all the lists of the user with the specified id to a list
            //var notes = await mContext.Notes.Include(x => x.CheckListItems).Where(x => x.UserId == userId).ToListAsync();

            //// Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            //// produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            //// response with all the lists
            //return Ok(mMapper.Map<IEnumerable<NoteResponseModel>>(notes));

            var noteResponseModels = await ControllersHelper.GetAllAsync<NoteRequestModel, NoteEntity, NoteResponseModel>(mContext.Notes, mMapper, "CheckListItems");

            return noteResponseModels;
        }

        /// <summary>
        /// Gets the list with the specified id
        /// </summary>
        /// <param name="noteId">The specified id</param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.UserNoteRoute)]
        public async Task<ActionResult<NoteResponseModel>> GetNoteAsync([FromRoute]int userId, [FromRoute]int noteId)
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
        public async Task<ActionResult<NoteResponseModel>> UpdateNoteAsync([FromRoute] int userId, [FromRoute] int noteId, [FromBody] NoteRequestModel model)
        {
            // Gets the list with the specified id from the database if exists
            var note = await mContext.Notes.Include(x => x.CheckListItems).FirstOrDefaultAsync(x => x.Id == noteId && x.UserId == userId);

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
        public async Task<ActionResult<NoteResponseModel>> DeleteNoteAsync([FromRoute] int userId, [FromRoute] int noteId)
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

        #region Check List Items

        /// <summary>
        /// Creates a new check list item and returns the note it belongs to 
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="noteId">The note's id</param>
        /// <param name="model">The check list item request model</param>
        /// Post fooli/users/2/notes/1/checkListItems
        [HttpPost]
        [Route(Routes.UserNoteCheckListItems)]
        public async Task<ActionResult<NoteResponseModel>> CreateCheckListItemAsync([FromRoute] int userId, [FromRoute] int noteId, [FromBody] CheckListItemRequestModel model)
        {
            // Gets the note with id the note id and user id the specified user id if exists
            var note = await mContext.Notes.FirstOrDefaultAsync(x => x.Id == noteId && x.UserId == userId);

            // If no note is found...
            if (note == null)
                // Returns not found
                return NotFound();
            
            var entity = mMapper.Map<CheckListItemEntity>(model);

            entity.NoteId = noteId;

            // Add the check list item
            mContext.CheckListItems.Add(entity);

            // Save the changes
            await mContext.SaveChangesAsync();

            // Finds the note entity with that item
            var noteEntity = await mContext.Notes.Include(x => x.CheckListItems).Where(x => x.Id == note.Id).FirstAsync();

            // Maps the entity to a response model
            var noteResponseModel = mMapper.Map<NoteResponseModel>(noteEntity);

            // Returns the note's response model that has the check list item
            return noteResponseModel;
        }

        /// <summary>
        /// Gets all the check list items of a user's note
        /// </summary>
        /// Get fooli/users/2/notes/1/checkListItems
        [HttpGet]
        [Route(Routes.UserNoteCheckListItems)]
        public async Task<ActionResult<IEnumerable<CheckListItemResponseModel>>> GetCheckListItemsAsync([FromRoute] int userId, [FromRoute] int noteId)
        {
            var items = await mContext.CheckListItems.Include(x => x.Note).Where(x => x.NoteId == noteId && x.Note.UserId == userId).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the check list items of the specified note
            return Ok(mMapper.Map<IEnumerable<CheckListItemResponseModel>>(items));
        }

        /// <summary>
        /// Gets the check list item of a user's note wit the specified id
        /// </summary>
        /// Get fooli/users/2/notes/1/checkListItems/5
        [HttpGet]
        [Route(Routes.UserNoteCheckListItem)]
        public async Task<ActionResult<IEnumerable<CheckListItemResponseModel>>> GetCheckListItemAsync([FromRoute] int userId, [FromRoute] int noteId, [FromRoute] int checkListItemId)
        {
            // Gets the model and maps it to the check list item entity from the database that has the specified ids
            var checkListItem = await mContext.CheckListItems.Include(x => x.Note).FirstOrDefaultAsync(x => x.NoteId == noteId && x.Id == checkListItemId && x.Note.UserId == userId);

            // If no check list item is found...
            if (checkListItem != null)
                // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
                // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
                // response with the checkListItem
                return Ok(mMapper.Map<CheckListItemResponseModel>(checkListItem));

            // If no items is found Creates an Microsoft.AspNetCore.Mvc.NotFoundResult that
            // produces a Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound
            // response.
            return NotFound();
        }

        /// <summary>
        /// Updates a check list item and returns the note it belongs to 
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="noteId">The note's id</param>
        /// <param name="checkListItemId">The check list item's id</param>
        /// <param name="model">The check list item request model</param>
        /// Put fooli/users/2/notes/1/checkListItems/3
        [HttpPut]
        [Route(Routes.UserNoteCheckListItem)]
        public async Task<ActionResult<NoteResponseModel>> UpdateCheckListItemAsync([FromRoute] int userId, [FromRoute] int noteId, [FromRoute] int checkListItemId, [FromBody] CheckListItemRequestModel model)
        {
            // Gets the model and maps it to the check list item entity from the database that has the specified ids
            var checkListItem = await mContext.CheckListItems.Include(x => x.Note).FirstOrDefaultAsync(x => x.NoteId == noteId && x.Id == checkListItemId && x.Note.UserId == userId);

            // If no check list item is found...
            if (checkListItem == null)
                // Return not found
                return NotFound();

            // If the model has text...
            if (model.Text != null)
                // Sets it as the items's text
                checkListItem.Text = model.Text;

            // If the model has a value on isChecked...
            if (model.IsChecked != null)
                // Sets it as the item's isChecked value
                checkListItem.IsChecked = (bool)model.IsChecked;

            // Saves the changes to the database
            await mContext.SaveChangesAsync();

            // Finds the note entity with that item
            var noteEntity = await mContext.Notes.Include(x => x.CheckListItems).Where(x => x.CheckListItems.Any(y => y.Id == checkListItemId)).FirstAsync();

            // Maps the entity to a response model
            var noteResponseModel = mMapper.Map<NoteResponseModel>(noteEntity);

            // Returns the note's response model that has the check list item
            return noteResponseModel;
        }

        /// <summary>
        /// Deletes a check list item with the specified id if exists and returns the note it was deleted from
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="noteId">The note's id</param>
        /// <param name="checkListItemId">The check list item's id</param>
        /// Delete fooli/users/2/notes/1/checkListItems/3
        [HttpDelete]
        [Route(Routes.UserNoteCheckListItem)]
        public async Task<ActionResult<NoteResponseModel>> DeleteCheckListItemAsync([FromRoute] int userId, [FromRoute] int noteId, [FromRoute] int checkListItemId)
        {
            // Gets the model and maps it to the check list item entity from the database that has the specified ids
            var checkListItem = await mContext.CheckListItems.Include(x => x.Note).FirstOrDefaultAsync(x => x.NoteId == noteId && x.Id == checkListItemId && x.Note.UserId == userId);

            // If no item is found...
            if (checkListItem == null)
                // Return not found
                return NotFound();

            // Finds the note entity with that item
            var noteEntity = await mContext.Notes.Include(x => x.CheckListItems).Where(x => x.CheckListItems.Any(y => y.Id == checkListItemId)).FirstAsync();

            mContext.CheckListItems.Remove(checkListItem);

            // Save the changes to the database
            await mContext.SaveChangesAsync();
            
            // Maps the entity to a response model
            var noteResponseModel = mMapper.Map<NoteResponseModel>(noteEntity);

            // Returns the note's response model that has the check list item
            return noteResponseModel;
        }

        #endregion

        #endregion
    }
}
