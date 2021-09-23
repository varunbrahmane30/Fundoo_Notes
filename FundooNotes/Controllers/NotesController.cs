//-----------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Varun">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using BusinessLayer.Interface;
    using CommonLayer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        readonly private INotesBL _notesBL;

        public NotesController(INotesBL notesBL)
        {
            this._notesBL = notesBL;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var Id = getTokenID();
            var useList = this._notesBL.getAllNotes(Id);
            return this.Ok(new { Success = true, message = "get notes SuccessFully.", Data = useList });
        }


        [HttpPost]
        public IActionResult CreateNote(NotesModel notesModel)
        {
            try
            {
                long userId = getTokenID();
                bool result = this._notesBL.CreateNotes(notesModel, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Created SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note Creation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = getTokenID();
                var result = this._notesBL.DeleteNotes(id, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Deleted SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }


        [HttpPut]
        [Route("{noteId}/pin")]
        public IActionResult IsPinned(long noteId)
        {
           
            try
            {
                var Id = getTokenID();
                var result = this._notesBL.IsPinned(Id, noteId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note pinned." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "pin remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut]
        [Route("color")]
        public IActionResult ChangeColor(long noteId,string color)
        {
            try
            {
                var Id = getTokenID();
                var result = _notesBL.ChangeColor(Id, noteId,color);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "color changed." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "color remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut]
        [Route("{noteId}/Archive")]
        public IActionResult IsArchive(long noteId)
        {
            try
            {
                var Id = getTokenID();
                var result = this._notesBL.IsArchive(Id, noteId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Archived." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Archive remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut]
        [Route("{noteId}/Trash")]
        public IActionResult IsTrash(long noteId)
        {
            try
            {
                var Id = getTokenID();
                var result = this._notesBL.IsTrash(Id, noteId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "note added into trash." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "note remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut]
        [Route("{id}/reminder")]
        public IActionResult AddReminder(long id, ReminderModel reminderModel)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.AddReminder(id, userId, reminderModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note reminder added SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "something wrong, reminder not added." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }


    }
}
