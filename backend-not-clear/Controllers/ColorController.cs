using backend_not_clear.DTO;
using backend_not_clear.DTO.ColorDTO.CreateColor;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private IColor service;
        public ColorController(IColor service)
        {
            this.service = service;
        }

        /// <summary>
        /// To customer see what color they can custom their cages
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "4")]
        [Route("get-for-custom")]
        [HttpGet]
        public async Task<IActionResult> GetForCustom()
        {
            ResponseAPI<List<Color>> responseAPI = new ResponseAPI<List<Color>>();
            try
            {
                responseAPI.Data = await this.service.GetByMaterial();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// For manager to manage color
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Color>> responseAPI = new ResponseAPI<List<Color>>();
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
        /// Allow manager to create new one
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("create-new")]
        [HttpPost]
        public async Task<IActionResult> CreateNewColor(CreateColor color)
        {
            ResponseAPI<Color> responseAPI = new ResponseAPI<Color>();
            try
            {
                responseAPI.Data = await this.service.CreateNewColor(color);
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
        public async Task<IActionResult> GetById(string id)
        {
            ResponseAPI<Color> responseAPI = new ResponseAPI<Color>();
            try
            {
                responseAPI.Data = await this.service.GetById(id);
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
