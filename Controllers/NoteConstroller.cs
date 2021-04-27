using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the notes
        /// </summary>
        protected IQueryable<NoteEntity> NotesQuery => mContext.Notes.Include(x => x.CheckListItems);

        /// <summary>
        /// The query used for retrieving the check list items
        /// </summary>
        protected IQueryable<CheckListItemEntity> CheckListItemsQuery => mContext.CheckListItems;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NoteConstroller(FooliDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        #region Notes

        /// <summary>
        /// Creates a new list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model">The list request model</param>
        /// Post fooli/lists
        [HttpPost]
        [Route(Routes.UserNotesRoute)]
        public Task<ActionResult<NoteResponseModel>> CreateNoteAsync([FromRoute] int userId, [FromBody] NoteRequestModel model) 
            => ControllersHelper.PostAsync<NoteEntity, NoteResponseModel>(
                mContext, 
                mContext.Notes, 
                NoteEntity.FromRequestModel(userId, model), 
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the lists from the database that belong to the user with the specified id
        /// </summary>
        /// Get fooli/users/{id}/lists
        [HttpGet]
        [Route(Routes.UserNotesRoute)]
        public Task<ActionResult<IEnumerable<NoteResponseModel>>> GetNotesAsync([FromRoute]int userId)
        {
            // Gets the response models
            return ControllersHelper.GetAllAsync<NoteEntity, NoteResponseModel>(
                NotesQuery, 
                x => x.UserId == userId);
        }

        /// <summary>
        /// Gets the list with the specified id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId">The specified id</param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.UserNoteRoute)]
        public Task<ActionResult<NoteResponseModel>> GetNoteAsync([FromRoute]int userId, [FromRoute]int noteId)
        {
            // Gets the response model
            return ControllersHelper.GetAsync<NoteEntity, NoteResponseModel>(
                NotesQuery,
                DI.GetMapper,
                 x => x.Id == noteId && x.UserId == userId);
        }

        /// <summary>
        /// Updates the list with the specified id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="noteId">The note's id</param>
        /// <param name="model">The list request model</param>
        /// Put fooli/users/5/notes/4
        [HttpPut]
        [Route(Routes.UserNoteRoute)]
        public Task<ActionResult<NoteResponseModel>> UpdateNoteAsync([FromRoute] int userId, [FromRoute] int noteId, [FromBody] NoteRequestModel model) 
            => ControllersHelper.PutAsync<NoteRequestModel, NoteEntity, NoteResponseModel>(
                mContext,
                NotesQuery,
                model,
                x => x.Id == noteId && x.UserId == userId);

        /// <summary>
        /// Deletes the note with the specified noteId and userId
        /// </summary>
        /// Delete /fooli/users/{userId}/notes/{noteId}
        [HttpDelete]
        [Route(Routes.UserNoteRoute)]
        public Task<ActionResult<NoteResponseModel>> DeleteNoteAsync([FromRoute] int userId, [FromRoute] int noteId)
        {
            return ControllersHelper.DeleteAsync<NoteEntity, NoteResponseModel>(
                mContext, 
                NotesQuery, 
                DI.GetMapper, 
                x => x.Id == noteId && x.UserId == userId);
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
            var checkListItem = await ControllersHelper.PostAsync(
                mContext,
                mContext.CheckListItems,
                CheckListItemEntity.FromRequestModel(noteId, model),
                x => x.ToResponseModel());
            
            // Maps the entity to a response model
            var noteResponseModel = await ControllersHelper.GetAsync<NoteEntity, NoteResponseModel>(
                NotesQuery,
                DI.GetMapper,
                x => x.Id == noteId);

            // Returns the note's response model that has the check list item
            return noteResponseModel;
        }

        /// <summary>
        /// Gets all the check list items of a user's note
        /// </summary>
        /// Get fooli/users/2/notes/1/checkListItems
        [HttpGet]
        [Route(Routes.UserNoteCheckListItems)]
        public Task<ActionResult<IEnumerable<CheckListItemResponseModel>>> GetCheckListItemsAsync([FromRoute] int userId, [FromRoute] int noteId)
        {
            return ControllersHelper.GetAllAsync<CheckListItemEntity, CheckListItemResponseModel>(
                CheckListItemsQuery, 
                x => x.NoteId == noteId && x.Note.UserId == userId);
        }

        /// <summary>
        /// Gets the check list item of a user's note wit the specified id
        /// </summary>
        /// Get fooli/users/2/notes/1/checkListItems/5
        [HttpGet]
        [Route(Routes.UserNoteCheckListItem)]
        public Task<ActionResult<CheckListItemResponseModel>> GetCheckListItemAsync([FromRoute] int userId, [FromRoute] int noteId, [FromRoute] int checkListItemId)
        {
            // Gets the response model
            return ControllersHelper.GetAsync<CheckListItemEntity, CheckListItemResponseModel>(
                CheckListItemsQuery,
                DI.GetMapper, 
                x => x.NoteId == noteId && x.Id == checkListItemId && x.Note.UserId == userId);
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
            // Updates the check list item
            var checkListItem = await ControllersHelper.PutAsync<CheckListItemRequestModel, CheckListItemEntity, CheckListItemResponseModel>(
                mContext,
                CheckListItemsQuery,
                model,
                x => x.Id == checkListItemId && x.NoteId == noteId);

            // Finds and maps the entity to a response model
            var noteResponseModel = await ControllersHelper.GetAsync<NoteEntity, NoteResponseModel>(
                NotesQuery,
                DI.GetMapper,
                x => x.UserId == userId && x.Id == noteId);

            // Returns the note's response model
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
            // Deletes the check list item
            var deletedCheckListItem = await ControllersHelper.DeleteAsync<CheckListItemEntity, CheckListItemResponseModel>(
                mContext, 
                CheckListItemsQuery, 
                DI.GetMapper, 
                x => x.NoteId == noteId && x.Id == checkListItemId && x.Note.UserId == userId);

            var noteResponseModel = await ControllersHelper.GetAsync<NoteEntity, NoteResponseModel>(
                NotesQuery, 
                DI.GetMapper,
                x => x.Id == noteId);

            // Returns the note's response model that has the check list item
            return noteResponseModel;
        }

        #endregion

        #endregion
    }
}
