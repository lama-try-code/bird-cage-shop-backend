using backend_not_clear.DTO;
using backend_not_clear.DTO.BirdDTO.BirdCreate;
using backend_not_clear.DTO.BirdDTO.UpdateBird;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private IBird service;
        public BirdController(IBird service)
        {
            this.service = service;
        }
        /// <summary>
        /// hihiihihihih
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
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

        [AllowAnonymous]
        [Route("get-for-sort")]
        [HttpGet]
        public async Task<IActionResult> GetForSort()
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
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

        [AllowAnonymous]
        [Route("search-name")]
        [HttpGet]
        public async Task<IActionResult> SearchByName(string name)
        {
            ResponseAPI<List<Bird>> responseAPI = new ResponseAPI<List<Bird>>();
            try
            {
                responseAPI.Data = await this.service.SearchByName(name);
                return Ok(responseAPI.Data);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateBird(CreateBird bird)
        {
            ResponseAPI<Bird> responseAPI = new ResponseAPI<Bird>();
            try
            {
                responseAPI.Data = await this.service.CreateBird(bird);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateBird(UpdateBird bird)
        {
            ResponseAPI<Bird> responseAPI = new ResponseAPI<Bird>();
            try
            {
                responseAPI.Data = await this.service.UpdateBird(bird);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBird(string BirdId)
        {
            ResponseAPI<Bird> responseAPI = new ResponseAPI<Bird>();
            try
            {
                responseAPI.Data = await this.service.DeleteBird(BirdId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [AllowAnonymous]
        [Route("get-bird-by-id")]
        [HttpGet]
        public async Task<IActionResult> getBirdById(string id)
        {
            ResponseAPI<Bird> responseAPI = new ResponseAPI<Bird>();
            try
            {
                responseAPI.Data = await this.service.getBirdByID(id);
                return Ok(responseAPI);
            }catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
