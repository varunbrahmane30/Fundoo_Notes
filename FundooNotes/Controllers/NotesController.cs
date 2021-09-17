using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{
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
        [Authorize]
        public IActionResult GetAllNotes()
        {
            var Id = getTokenID();
            var useList = this._notesBL.getAllNotes(Id);
            return this.Ok(new { Success = true, message = "get notes SuccessFully.", Data = useList });
        }


        [HttpPost]
        [Authorize]
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
        
        [HttpDelete("{id:long}")]
        [Authorize]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = getTokenID();
                var result = this._notesBL.DeleteNotes(id,userId);

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

        [HttpPut("{id:long}")]
        //[Authorize]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.UpdateNotes(id, userId,notesModel);

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


    }
}
