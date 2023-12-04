using backend_not_clear.Interface;
using backend_not_clear.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;
using backend_not_clear.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using backend_not_clear.DTO.UserDTO.SearchUserID;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser service;
        public UserController(IUser service)
        {
            this.service = service;
        }

        /// <summary>
        /// For admin to see all account in system
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<User>> responeAPI = new ResponseAPI<List<User>>();
            try
            {
                responeAPI.Data = await this.service.GetAll();
                return Ok(responeAPI);
            }
            catch (Exception ex)
            {
                responeAPI.message = ex.Message;
                return BadRequest(responeAPI);
            }
        }

        /// <summary>
        /// Get information of user - all user can see to update
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-user-information")]
        [HttpPost]
        public async Task<IActionResult> GetUserInforMation(SearchUserID user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.GetUserInformation(user);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Admin search user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("search-by-name")]
        [HttpPost]
        public async Task<IActionResult> SearchUserByFullName(SearchByFullNameDTO request)
        {
            ResponseAPI<List<User>> responseAPI = new ResponseAPI<List<User>>();
            try
            {
                responseAPI.Data = await this.service.SearchByName(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest($"{responseAPI}");
            }
        }

        /// <summary>
        /// Login with username, password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.Login(user);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDTO user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.Update(user);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let Admin remove account out of system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("remove")]
        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveDTO user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.Remove(user);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// register for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterDTO user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.Registration(user);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "1")]
        [Route("create-user")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.CreateUser(user);
                return Ok(responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [AllowAnonymous]
        [Route("coutn-all-customers")]
        [HttpGet]
        public async Task<IActionResult> countCustomers()
        {
            ResponseAPI<User> responseAPI = new ResponseAPI<User>();
            try
            {
                responseAPI.Data = await this.service.countCustomers();
                return Ok(responseAPI);
            }catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
