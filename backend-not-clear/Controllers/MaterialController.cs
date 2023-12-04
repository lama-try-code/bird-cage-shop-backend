using backend_not_clear.DTO;
using backend_not_clear.DTO.MaterialDTO.CreateMaterial;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterial service;
        public MaterialController(IMaterial service)
        {
            this.service = service;
        }

        /// <summary>
        /// Let customer see what material they can custom for their cage
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("get-for-custom")]
        [HttpGet]
        public async Task<IActionResult> GetForCustom(string sizeId)
        {
            ResponseAPI<List<Material>> responseAPI = new ResponseAPI<List<Material>>();
            try
            {
                responseAPI.Data = await this.service.GetBySize(sizeId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Material>> responseAPI = new ResponseAPI<List<Material>>(); 
            try
            {
                responseAPI.Data = await this.service.GetAll();
                return Ok(responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseAPI<Material> responseAPI = new ResponseAPI<Material>();
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
