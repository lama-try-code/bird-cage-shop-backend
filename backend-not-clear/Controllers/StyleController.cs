using backend_not_clear.DTO;
using backend_not_clear.DTO.StyleDTO.CreateStyle;
using backend_not_clear.DTO.StyleDTO.SearchStyle;
using backend_not_clear.DTO.StyleDTO.UpdateStyle;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private IStyle service;
        public StyleController(IStyle service)
        {
            this.service = service;
        }

        /// <summary>
        /// allow manager to see and decide
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Style>> responseAPI = new ResponseAPI<List<Style>>();
            try
            {
                responseAPI.Data = await this.service.GetAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let guest/customer see 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-for-customer")]
        [HttpGet]
        public async Task<IActionResult> GetForCustomer()
        {
            ResponseAPI<List<Style>> responseAPI = new ResponseAPI<List<Style>>();
            try
            {
                responseAPI.Data = await this.service.GetForSort();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let customer see to custom
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "4")]
        [AllowAnonymous]
        [Route("get-for-custom")]
        [HttpGet]
        public async Task<IActionResult> GetForCustom()
        {
            ResponseAPI<List<Style>> responseAPI = new ResponseAPI<List<Style>>();
            try
            {
                responseAPI.Data = await this.service.GetByCustom();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let manager to create new one
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        [Authorize(Roles = "2, 4")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateStyle(CreateStyle style)
        {
            ResponseAPI<Style> responseAPI = new ResponseAPI<Style>();
            try
            {
                responseAPI.Data = await this.service.CreateStyle(style);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let manager to delete
        /// </summary>
        /// <param name="styleId"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStyle(string styleId)
        {
            ResponseAPI<Style> responseAPI = new ResponseAPI<Style>();
            try
            {
                responseAPI.Data = await this.service.DeleteStyle(styleId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(string styleId)
        {
            ResponseAPI<Style> responseAPI = new ResponseAPI<Style>();
            try
            {
                responseAPI.Data = await this.service.GetById(styleId);
                return Ok(responseAPI);
            }
            catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
