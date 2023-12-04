using backend_not_clear.DTO;
using backend_not_clear.DTO.BlogDTO;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlog service;
        public BlogController(IBlog service)
        {
            this.service = service;
        }

        /// <summary>
        /// Let user see blog 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            ResponseAPI<List<Blog>> responeAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responeAPI.Data = await this.service.GetAll();
                return Ok(responeAPI);
            }
            catch (Exception ex)
            {
                responeAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("get-for-customer")]
        [HttpGet]
        public async Task<IActionResult> GetForCustomer()
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.GetForCustomer();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Allow staff create new one
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "3")]
        [Route("create-blog")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDTO request)
        {
            ResponseAPI<Blog> responseAPI = new ResponseAPI<Blog>();
            try
            {
                responseAPI.Data = await this.service.CreateBlog(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Allow staff update the old one
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "3")]
        [Route("update-blog")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDTO request)
        {
            ResponseAPI<Blog> responseAPI = new ResponseAPI<Blog>();
            try
            {
                responseAPI.Data = await this.service.UpdateBlog(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Let all user choose blog to read
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [Route("get-blog-by-id")]
        [HttpPost]
        public async Task<IActionResult> getBlogById(GetBlogByID request)
        {
            ResponseAPI<Blog> response = new ResponseAPI<Blog>();
            try
            {
                response.Data = await this.service.GetById(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Allow staff remove 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Authorize(Roles = "3")]
        [Route("remove-blog")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(RemoveBlog request)
        {
            ResponseAPI<Blog> responseAPI = new ResponseAPI<Blog>();
            try
            {
                responseAPI.Data = await this.service.RemoveBlog(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Let all user search by title
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [Route("search-blog-by-title")]
        [HttpPost]
        public async Task<IActionResult> SearchBlogByTitle(SearchBlogByTitle request)
        {
            ResponseAPI<Blog> responseAPI = new ResponseAPI<Blog>();
            try
            {
                responseAPI.Data = await this.service.SearchBlogByTitle(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Allow user search by type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [Route("search-blog-by-type")]
        [HttpPost]
        public async Task<IActionResult> SearchBlogByType(SearchBlogByType request)
        {
            ResponseAPI<Blog> responseAPI = new ResponseAPI<Blog>();
            try
            {
                responseAPI.Data = await this.service.SearchBlogByType(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        [AllowAnonymous]
        [Route("suggest-blogs-bloginformatinpage")]
        [HttpPost]
        public async Task<IActionResult> suggestBlog(string type)
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.suggestBlog(type);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        [AllowAnonymous]
        [Route("get-first-4-blogs")]
        [HttpPost]
        public async Task<IActionResult> getEachBlogType()
        {
            ResponseAPI<List<Blog>> responseAPI = new ResponseAPI<List<Blog>>();
            try
            {
                responseAPI.Data = await this.service.getEachBlogType();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

    }
}
