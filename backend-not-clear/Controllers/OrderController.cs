using backend_not_clear.DTO;
using backend_not_clear.DTO.OrderDTO.CreateOrder;
using backend_not_clear.DTO.OrderDTO.CreateOrderCustom;
using backend_not_clear.DTO.OrderDTO.ReturnOrdersByMonth;
using backend_not_clear.DTO.OrderDTO.SearchOrder;
using backend_not_clear.DTO.OrderDTO.UpdateOrder;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrder service;
        public OrderController(IOrder service)
        {
            this.service = service;
        }

        /// <summary>
        /// Let Customer see their cart which not paid
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("get-not-paid")]
        [HttpPost]
        public async Task<IActionResult> GetOrderNotFinishedForUser(SearchOrder search)
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetOrderNotFinishedForUser(search);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }


        /// <summary>
        /// Let Customer see their cart which paid
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("get-paid")]
        [HttpPost]
        public async Task<IActionResult> GetOrderFinishedForUser(SearchOrder search)
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetOrderFinishedForUser(search);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Create at first time when add product
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("create-new")]
        [HttpPost]
        public async Task<IActionResult> CreateNew(CreateOrder order)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.CreateNew(order);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        ///// <summary>
        ///// Let them paid
        ///// </summary>
        ///// <param name="OrderID"></param>
        ///// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("paid")]
        [HttpPost]
        public async Task<IActionResult> FinishPayment(string OrderID)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.FinishPayment(OrderID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// use when user add product to calculate total
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("update-order-to-add-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrder order)
        {
            ResponseAPI<Order> resposneAPI = new ResponseAPI<Order>();
            try
            {
                resposneAPI.Data = await this.service.UpdateOrder(order);
                return Ok(resposneAPI);
            }
            catch (Exception ex)
            {
                resposneAPI.message = ex.Message;
                return BadRequest(resposneAPI);
            }
        }
        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
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
        [Route("count-orders")]
        [HttpGet]
        public async Task<IActionResult> countAllOrder()
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.countAllOrder();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [AllowAnonymous]
        [Route("get-Orders-By-Month")]
        [HttpGet]
        public async Task<IActionResult> getByMonth()
        {
            ResponseAPI<List<ReturnOrdersByMonth>> responseAPI = new ResponseAPI<List<ReturnOrdersByMonth>>();
            try
            {
                responseAPI.Data = await this.service.getOrdersByMonth();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("get-custom-order")]
        [HttpPost]
        public async Task<IActionResult> GetCustomOrder(SearchOrder search)
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetCustomOrder(search);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("create-new-custom-product")]
        [HttpPost]
        public async Task<IActionResult> CreateNewCustomOrder(CreateCustomOrder product)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.CreateNewCustomOrder(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-to-confirm")]
        [HttpGet] 
        public async Task<IActionResult> GetOrderToConfirm()
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetOrderToConfirm();
                return Ok(responseAPI);
            } 
            catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-custom-confirm")]
        [HttpGet] 
        public async Task<IActionResult> GetCustomOrderToConfirm()
        {
            ResponseAPI<List<Order>> responseAPI = new ResponseAPI<List<Order>>();
            try
            {
                responseAPI.Data = await this.service.GetCustomOrderToConfirm();
                return Ok(responseAPI);
            } 
            catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("remove-order")]
        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(string OrderId)
        {
            ResponseAPI<Order> responseAPI = new ResponseAPI<Order>();
            try
            {
                responseAPI.Data = await this.service.RemoveOrder(OrderId);
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
