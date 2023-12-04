
using backend_not_clear.DTO.VoucherUserOrderDTO.CreatyVoucherUserOrder;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IVoucherUserOrder
    {
        public Task<List<VoucherUserOrder>> getAllVoucherUser();
        public Task<VoucherUserOrder> GetVoucherByID(String VoucherID);
        public Task<bool> Delete(String VoucherID);
        public Task<VoucherUserOrder> CreateVoucherU(CreateVoucherUserOrder voucher);
        public Task<bool> UpdateStatus(string VoucherID);


    }
}
