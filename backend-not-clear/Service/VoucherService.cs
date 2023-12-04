
using backend_not_clear.Interface;

using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System;
using backend_not_clear.DTO.VoucherDTO.CreatyVoucher;
using backend_not_clear.Models;

namespace backend_not_clear.Service
{
    public class VoucherService : IVoucher
    {
        private readonly BCS_ShopContext _context;

        public VoucherService(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<Voucher> CreateVoucher(CreateVoucher voucher)
        {
            try
            {
                var create = new Voucher();
                create.VoucherId = "V" + Guid.NewGuid().ToString().Substring(0, 8);
                create.VoucherName = voucher.VoucherName;
                create.Description = voucher.Description;
                create.Discount = voucher.Discount;
                create.StartDate = voucher.StartDate;
                create.EndDate = voucher.EndDate;
                create.CreateAt = DateTime.Now;
                create.Status = true;

                await this._context.Voucher.AddAsync(create);
                await this._context.SaveChangesAsync();
                return create;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create Voucher: {ex.Message}");
            }
        }

        public async Task<Voucher> DeleteVoucher(string voucherId)
        {
            try
            {
                var delete = await this._context.Voucher.Where(x => x.VoucherId.Equals(voucherId) 
                                                          && x.Status)
                                                        .FirstOrDefaultAsync();
                if (delete == null) return null;
                else
                {
                    delete.Status = false;
                    this._context.Voucher.Update(delete);
                    await this._context.SaveChangesAsync();
                    return delete;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Voucher>> GetAll()
        {
            try
            {
                var list = await this._context.Voucher.Where(x => x.Status).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Voucher>> GetForUser()
        {
            try
            {
                var list = await this._context.Voucher.Where(x => x.Status).ToListAsync();
                var voucherList = new List<Voucher>();
                foreach (var voucher in list)
                {
                    if (DateTime.Compare(DateTime.UtcNow, voucher.EndDate) < 0)
                    {
                        voucherList.Add(voucher);
                    }
                }
                return voucherList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Voucher> GetVoucherById(string voucherId)
        {
            try
            {
                var found = await this._context.Voucher.Where(x => x.VoucherId.Equals(voucherId) && x.Status)
                                                       .FirstOrDefaultAsync();
                return found;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
