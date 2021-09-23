using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{

    [Authorize]
    [Route("{noteId}")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        readonly private ILabelBL _labalBL;

        public LabelController(ILabelBL labalBL)
        {
                this._labalBL = labalBL;
        }

      
        [HttpPost]
        [Route("label")]
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
        [Route("label")]
        public IActionResult DeleteLabel(long lableId)
        {
            try
            {

                var result = _labalBL.DeleteLabel(lableId);
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
        [Route("label")]
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