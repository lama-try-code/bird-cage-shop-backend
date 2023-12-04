using backend_not_clear.DTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPayment service;
        public PaymentController(IPayment service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("create-payment")]
        public async Task<IActionResult> createPayment(string OrderId)
        {
            ResponseAPI<Payment> responseAPI = new ResponseAPI<Payment>();
            try
            {
                responseAPI.Data = await this.service.createPayment(OrderId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpGet]
        [Route("get-payment")]
        public async Task<IActionResult> GetPayment(string OrderId)
        {
            ResponseAPI<Payment> responseAPI = new ResponseAPI<Payment>();
            try
            {
                responseAPI.Data = await this.service.GetPayment(OrderId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpPost]
        [Route("paid")]
        public async Task<IActionResult> UpdatePaymentForCOD(string paymentId)
        {
            ResponseAPI<Payment> responseAPI = new ResponseAPI<Payment>();
            try
            {
                responseAPI.Data = await this.service.UpdatePaymentForCOD(paymentId);
                return Ok (responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    } 
}
