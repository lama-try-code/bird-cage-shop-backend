
using backend_not_clear.DTO.VoucherDTO.CreatyVoucher;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IVoucher
    {
        //Get For Manager
        Task<List<Voucher>> GetAll();
        //Get for customer
        Task<List<Voucher>> GetForUser();
        //Create new Voucher
        Task<Voucher> CreateVoucher(CreateVoucher voucher);
        //Delete Voucher
        Task<Voucher> DeleteVoucher(string  voucherId);
        Task<Voucher> GetVoucherById(string voucherId);
    }
}
