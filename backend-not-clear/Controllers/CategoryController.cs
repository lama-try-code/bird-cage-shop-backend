using backend_not_clear.DTO;
using backend_not_clear.DTO.CategoryDTO.CreateCategory;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategory service;
        public CategoryController(ICategory service)
        {
            this.service = service;
        }
        /// <summary>
        /// For managers to search and add more if them wants
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Category>> responseAPI = new ResponseAPI<List<Category>>();
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
        /// For manager to create
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategory category)
        {
            ResponseAPI<Category> responseAPI = new ResponseAPI<Category>();
            try
            {
                responseAPI.Data = await this.service.CreateCategory(category);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

    }
}
