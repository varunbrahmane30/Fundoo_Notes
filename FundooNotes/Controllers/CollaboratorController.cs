using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("Collaborator")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {

        readonly private ICollaboratorBL _collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this._collaboratorBL = collaboratorBL;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }
        [HttpGet]
        [Route("{noteId}")]
        public IActionResult GetCollborator(long noteId)
        {
            //var Id = getTokenID();
            var useList = this._collaboratorBL.GetCollaboratorsId(noteId);
            return this.Ok(new { Success = true, message = "get Collaborators SuccessFully.", Data = useList });
        }


        [HttpPost]
        [Route("{noteId}")]
        public IActionResult AddCollaborator(long noteId, AddCollaboratorRequest collaborators)
        {
            try
            {
                var userId = getTokenID();
                if (_collaboratorBL.AddCollborators(userId, noteId, collaborators))
                {
                    return this.Ok(new { Success = true, message = "collaborator added SuccessFully.", noteId });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "collaborator not added" });
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
        [Route("{noteId}")]
        public IActionResult DeleteCollaborator(long noteId, AddCollaboratorRequest collaborators)
        {
            try
            {
                var userId = getTokenID();
                if (_collaboratorBL.DeleteCollborators(userId, noteId, collaborators))
                {
                    return this.Ok(new { Success = true, message = "collaborator deleted SuccessFully.", noteId });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "collaborator not deleted" });
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