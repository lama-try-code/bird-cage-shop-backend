using backend_not_clear.DTO;
using backend_not_clear.DTO.FeedbackDTO.CreateFeedback;
using backend_not_clear.DTO.FeedbackDTO.RemoveFeedback;
using backend_not_clear.DTO.FeedbackDTO.ReplyFeedback;
using backend_not_clear.DTO.FeedbackDTO.UpdateFeedback;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback service;

        public FeedbackController(IFeedback service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        [Route("create-feedback")]
        [HttpPut]
        public async Task<IActionResult> CreateFeedback(CreateFeedback request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.CreateFeedback(request);
                return Ok(responseAPI);
            }catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "3")]
        [Route("create-reply-feedback")]
        [HttpPut]
        public async Task<IActionResult> CreateReplyFeedback(ReplyFeedback request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.Reply(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("update-feedback")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeedback(UpdateFeedback request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.UpdateFeedback(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("update-reply-feedback")]
        [HttpPut]
        public async Task<IActionResult> UpdateReplyFeedback(UpdateReply request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.UpdateReply(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("remove-feedback")]
        [HttpDelete]
        public async Task<IActionResult> RemoveFeedback(RemoveFeedback request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.RemoveFeedback(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("remove-reply-feedback")]
        [HttpDelete]
        public async Task<IActionResult> RemoveReply(RemoveReply request)
        {
            ResponseAPI<FeedBack> responseAPI = new ResponseAPI<FeedBack>();
            try
            {
                responseAPI.Data = await service.RemoveReply(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }
    }
}
