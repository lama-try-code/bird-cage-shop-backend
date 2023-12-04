
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using backend_not_clear.DTO.VoucherUserOrderDTO.CreatyVoucherUserOrder;
using backend_not_clear.DTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class VoucherUserOrderController : ControllerBase
    {
        private IVoucherUserOrder service;
        public VoucherUserOrderController(IVoucherUserOrder service)
        {
            this.service = service;
        }
        [Route("create-voucherUserOrder")]
        [HttpPost]
        public async Task<IActionResult> CreateVoucherUserOrder(CreateVoucherUserOrder voucher)
        {
            try
            {
                VoucherUserOrder voucherUserOrder = await this.service.CreateVoucherU(voucher);

                // Tạo đối tượng mới chỉ chứa VoucherUserOrder
                var response = new { VoucherUserOrder = voucherUserOrder };

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    // Các tùy chọn khác nếu cần
                };

                // Serialize đối tượng mới thành JSON
                var json = JsonSerializer.Serialize(response, options);

                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("get-all-voucheruserorder")]
        [HttpGet]
        public async Task<IActionResult> getAllVoucherU()
        {
            ResponseAPI<List<VoucherUserOrder>> responseAPI = new ResponseAPI<List<VoucherUserOrder>>();
            try
            {
                responseAPI.Data = await this.service.getAllVoucherUser();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-voucheruserorder")]
        [HttpDelete]
        public async Task<IActionResult> Delete(String userId)
        {
            ResponseAPI<VoucherUserOrder> responseAPI = new ResponseAPI<VoucherUserOrder>();
            try
            {
                responseAPI.Data = await this.service.Delete(userId);
                if ((bool)responseAPI.Data)
                {
                    responseAPI.message = "Delete Successful";
                }
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }

        }


        [Route("find-VoucherUser-by-name")]
        [HttpGet]
        public async Task<IActionResult> getUserByName(String VoucherID)
        {
            ResponseAPI<VoucherUserOrder> responseAPI = new ResponseAPI<VoucherUserOrder>();
            try
            {
                responseAPI.Data = await this.service.GetVoucherByID(VoucherID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(ex.Message);
            }
        }
        [Route("update-status-voucheruser")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(string VoucherID)
        {
            ResponseAPI<VoucherUserOrder> responseAPI = new ResponseAPI<VoucherUserOrder>();
            try
            {
                bool result = await this.service.UpdateStatus(VoucherID);
                responseAPI.Data = result;
                if (result)
                {
                    responseAPI.message = "Update Status Successful";
                }
                else
                {
                    responseAPI.message = "Update Status Failed";
                }
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
