
using backend_not_clear.DTO.VoucherUserOrderDTO.CreatyVoucherUserOrder;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class VoucherUserOrderService : IVoucherUserOrder
    {
        private readonly BCS_ShopContext _context;

        public VoucherUserOrderService(BCS_ShopContext context)
        {
            _context = context;
        }
        public async Task<VoucherUserOrder> CreateVoucherU(CreateVoucherUserOrder voucherUO)
        {
            try
            {
                // Check if OrderId, VoucherId, and UserId exist in the system
                var order = await this._context.Order.FindAsync(voucherUO.OrderId);
                var voucher = await this._context.Voucher.FindAsync(voucherUO.VoucherID);
                var user = await this._context.User.FindAsync(voucherUO.UserId);

                if (order == null || voucher == null || user == null)
                {
                    throw new Exception("OrderId, VoucherId, or UserId not found in the system.");
                }

                // Create a new VoucherUserOrder object
                var add = new VoucherUserOrder
                {
                    VoucherId = voucherUO.VoucherID,
                    OrderId = voucherUO.OrderId,
                    UserId = voucherUO.UserId,
                    Status = true // Set the Status field (true or false as needed)
                };

                // Check and assign a value to UseDate
                if (voucherUO.UseDate != null)
                {
                    add.UseDate = voucherUO.UseDate;
                }
                else
                {
                    // Handle the case when UseDate is null
                    // For example, you can set it to DateTime.Now or throw an exception
                    // add.UseDate = DateTime.Now;
                    // OR
                    // throw new Exception("UseDate is null");
                }

                // Add the VoucherUserOrder object to DbSet and save changes
                this._context.VoucherUserOrder.Add(add);
                await this._context.SaveChangesAsync();

                return add;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // Consider using a logging framework like Serilog or NLog
                // logger.LogError(ex, "Error creating VoucherUserOrder");

                throw new Exception($"Failed to create VoucherUserOrder: {ex.Message}");
            }
        }




        public async Task<bool> Delete(string VoucherID)
        {
            bool isDelete = false;
            try
            {
                // Tìm bản ghi Voucher theo VoucherID
                var voucherToDelete = await this._context.VoucherUserOrder.FirstOrDefaultAsync(v => v.VoucherId == VoucherID);

                if (voucherToDelete != null)
                {
                    // Xóa bản ghi Voucher nếu tìm thấy
                    this._context.VoucherUserOrder.Remove(voucherToDelete);
                    await this._context.SaveChangesAsync();
                    isDelete = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete: {ex.Message}");
            }
            return isDelete;
        }

        public async Task<List<VoucherUserOrder>> getAllVoucherUser()
        {
            try
            {
                var list = await this._context.VoucherUserOrder.Select(x => new VoucherUserOrder
                {
                    VoucherId = x.VoucherId,
                    OrderId = x.OrderId,
                    UserId = x.UserId,
                    UseDate = x.UseDate,
                    Status = x.Status,




                }).ToListAsync();
                if (list != null)
                {
                    return list;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<VoucherUserOrder> GetVoucherByID(string VoucherID)
        {
            try
            {
                // Tìm bản ghi Voucher dựa trên VoucherName
                var find = await this._context.VoucherUserOrder.FirstOrDefaultAsync(v => v.VoucherId == VoucherID);

                if (find == null)
                {
                    // Nếu không tìm thấy, trả về null hoặc có thể xử lý tùy theo yêu cầu của bạn
                    throw new Exception($"Voucher with ID '{VoucherID}' not found.");
                }

                return find;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi tương ứng
                throw new Exception($"Failed to get Voucher by name: {ex.Message}");
            }
        }

        public async Task<bool> UpdateStatus(string VoucherID)
        {
            try
            {
                // Tìm VoucherUserOrder với VoucherID đã cho.
                var voucherUserOrder = await _context.VoucherUserOrder.FindAsync(VoucherID);

                if (voucherUserOrder == null)
                {
                    throw new Exception("Không tìm thấy VoucherUserOrder");
                }


                if (voucherUserOrder.UseDate != DateTime.Today)
                {

                    voucherUserOrder.Status = false;

                    // Lưu thay đổi vào cơ sở dữ liệu.
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái: {ex.Message}");
            }
        }
    }


}

