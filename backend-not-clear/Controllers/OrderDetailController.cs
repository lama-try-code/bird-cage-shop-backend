using backend_not_clear.DTO;
using backend_not_clear.DTO.OrderDetailDTO.CreateOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.RemoveOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.UpdateOrderDetail;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetail service;
        public OrderDetailController(IOrderDetail service)
        {
            this.service = service;
        }

        /// <summary>
        /// Call when user add new product
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("create-new")]
        [HttpPost]
        public async Task<IActionResult> CreateNewOrderDetail(CreateOrderDetail order)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.CreateNewOrderDetail(order);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Call when user delete product out of cart
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("remove-or-temporary")]
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(RemoveOrderDetail order)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.RemoveOrderDetail(order);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Call when user update product inside cart
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [Authorize(Roles = "4")]
        [Route("update-detail")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetail order)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.UpdateOrderDetail(order);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("remove-all-detail")]
        [HttpDelete]
        public async Task<IActionResult> RemoveAllorderDetal(string request)
        {
            ResponseAPI<OrderDetail> responseAPI = new ResponseAPI<OrderDetail>();
            try
            {
                responseAPI.Data = await this.service.RemoveAllDetail(request);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("confirm-order")]
        [HttpPut]
        public async Task<IActionResult> FinishConfirmOrder(string orderID)
        {
            ResponseAPI<List<OrderDetail>> responseAPI = new ResponseAPI<List<OrderDetail>>();
            try
            {
                responseAPI.Data = await this.service.FinishConfirmOrder(orderID);
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
