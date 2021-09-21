using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{

    [Authorize]
    [Route("Label")]
    [ApiController]
    public class LabalController : ControllerBase
    {
        readonly private ILabelBL _labalBL;

        public LabalController(ILabelBL labalBL)
        {
                this._labalBL = labalBL;
        }

      
        [HttpPost]
        [Route("{noteId}")]
        public IActionResult AddLabel(long noteId,AddLabelRequest label)
        {
            try
            {
            
                var result = _labalBL.AddLabel(noteId,label);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "lable added SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "lable not added" });
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
        public IActionResult DeleteLabel(long noteId, AddLabelRequest label)
        {
            try
            {

                var result = _labalBL.DeleteLabel(noteId, label);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "lable Deleted SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Something Wrong,lable is not deleted." });
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
        [Route("{lebelid}")]
        public IActionResult UpdateLabel(long lebelid, AddLabelRequest label)
        {
            try
            {
                var result = this._labalBL.UpdateLabel(lebelid,label);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "lable updated SuccessFully.", lebelid });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "label updation failed." });
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