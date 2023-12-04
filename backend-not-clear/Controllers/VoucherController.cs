
using backend_not_clear.DTO.VoucherDTO.CreatyVoucher;
using backend_not_clear.DTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private IVoucher service;
        public VoucherController(IVoucher service)
        {
            this.service = service;
        }

        [Authorize(Roles = "2")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.GetAll();
                return Ok(responseAPI);
            } catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "4")]
        [Route("get-for-user")]
        [HttpGet]
        public async Task<IActionResult> GetForUser()
        {
            ResponseAPI<List<Voucher>> responseAPI = new ResponseAPI<List<Voucher>>();
            try
            {
                responseAPI.Data = await this.service.GetForUser();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("create-voucher")]
        [HttpPost]
        public async Task<IActionResult> CreateVoucher(CreateVoucher voucher)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.CreateVoucher(voucher);
                return Ok(responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "2")]
        [Route("delete-voucher")]
        [HttpDelete] 
        public async Task<IActionResult> DeleteVoucher(string voucherId)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.DeleteVoucher(voucherId);
                return Ok(responseAPI);
            }
            catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Authorize(Roles = "4")]
        [Route("get-by-id")]
        [HttpGet] 
        public async Task<IActionResult> GetById(string voucherId)
        {
            ResponseAPI<Voucher> responseAPI = new ResponseAPI<Voucher>();
            try
            {
                responseAPI.Data = await this.service.GetVoucherById(voucherId);
                return Ok(responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
