using backend_not_clear.DTO;
using backend_not_clear.DTO.SizeDTO.CreateForCustom;
using backend_not_clear.DTO.SizeDTO.CreateSize;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private ISize service;
        public SizeController(ISize service)
        {
            this.service = service;
        }

        /// <summary>
        /// Let manager see and decide
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Size>> responseAPI = new ResponseAPI<List<Size>>();
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
        /// Let guest/customer see to sort 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-for-sort")]
        [HttpGet]
        public async Task<IActionResult> GetForSort()
        {
            ResponseAPI<List<Size>> responseAPI = new ResponseAPI<List<Size>>();
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
        /// Let Manager create new one
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateSize(CreateSize size)
        {
            ResponseAPI<Size> responseAPI = new ResponseAPI<Size>();
            try
            {
                responseAPI.Data = await this.service.CreateSize(size);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// get async with style choose
        /// </summary>
        /// <param name="styleid"></param>
        /// <returns></returns>
        //[Authorize(Roles = "4")]
        [HttpGet]
        [Route("get-by-style")]
        public async Task<IActionResult> GetByStyle(string styleid)
        {
            ResponseAPI<List<Style>> responseAPI = new ResponseAPI<List<Style>>();
            try
            {
                responseAPI.Data = await this.service.GetByStyle(styleid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpGet("uniqueNames")]
        public async Task<IActionResult> GetUniqueSizeNames(string styleId)
        {
            ResponseAPI<IEnumerable<string>> responseAPI = new ResponseAPI<IEnumerable<string>>();
            try
            {
                responseAPI.Data = await this.service.GetUniqueSizeNames(styleId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("get-by-name")]
        public async Task<IActionResult> GetByName(string SizeName)
        {
            ResponseAPI<List<Size>> responseAPI = new ResponseAPI<List<Size>>();
            try
            {
                responseAPI.Data = await this.service.GetByName(SizeName);
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
            ResponseAPI<Size> responseAPI = new ResponseAPI<Size>();
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
