using backend_not_clear.DTO.OrderDetailDTO;
using backend_not_clear.DTO.OrderDetailDTO.CreateOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.RemoveOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.UpdateOrderDetail;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace backend_not_clear.Service
{
    public class OrderDetailService : IOrderDetail
    {
        private readonly BCS_ShopContext _context;

        const string pattern = @"PDT(?!C)\w*(\d+)";

        public OrderDetailService(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderDetail> CreateNewOrderDetail(CreateOrderDetail order)
        {
            try
            {
                var product = await this._context.Product.Where(x => x.ProductId.Equals(order.ProductId))
                                    .FirstOrDefaultAsync();
                if (product != null)
                {
                    var add = new OrderDetail();
                    add.OrderId = order.OrderId;
                    add.ProductId = order.ProductId;
                    add.FeedbackId = order.FeedbackId;
                    add.Quantity = order.Quantity;
                    add.Price = product.Price;
                    add.Status = false;
                    if (Regex.IsMatch(order.ProductId, pattern))
                        add.IsCustom = false;
                    else
                        add.IsCustom = true;
                    await this._context.OrderDetail.AddAsync(add);
                    await this._context.SaveChangesAsync();
                    return add;
                }
                else
                {
                    throw new Exception($"Invalid product");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetail> RemoveOrderDetail(RemoveOrderDetail order)
        {
            try
            {
                var product = await this._context.Product.Where(x => x.ProductId.Equals(order.ProductId))
                                    .FirstOrDefaultAsync();
                if (product != null)
                {
                    var remove = await this._context.OrderDetail.Where(x => x.OrderId.Equals(order.OrderId)
                                                                       && x.ProductId.Equals(order.ProductId))
                                        .FirstOrDefaultAsync();
                    if (remove != null)
                    {
                        this._context.OrderDetail.Remove(remove);
                        await this._context.SaveChangesAsync();
                        return remove;
                    }
                    return null;
                }
                else
                {
                    throw new Exception($"Invalid product");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetail> UpdateOrderDetail(UpdateOrderDetail order)
        {
            try
            {
                var product = await this._context.Product.Where(x => x.ProductId.Equals(order.ProductId))
                                    .FirstOrDefaultAsync();
                if (product != null)
                {
                    var update = await this._context.OrderDetail.Where(x => x.OrderId.Equals(order.OrderId)
                                                                       && x.ProductId.Equals(order.ProductId))
                                        .FirstOrDefaultAsync();
                    if (update != null)
                    {
                        if (order.Quantity == 0)
                        {
                            this._context.OrderDetail.Remove(update);
                            await this._context.SaveChangesAsync();
                        }
                        else
                        {
                            update.FeedbackId = order.FeedbackId;
                            update.Quantity = order.Quantity;
                            update.Price = product.Price;
                            update.Status = order.Status;
                            this._context.Update(update);
                            await this._context.SaveChangesAsync();
                            return update;
                        }
                    }
                    return null;
                }
                else
                {
                    throw new Exception($"Invalid product");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<OrderDetail>> RemoveAllDetail(string orderID)
        {
            try
            {
                var list = await this._context.OrderDetail.Where(x => x.OrderId.Equals(orderID)).ToListAsync();
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        this._context.OrderDetail.Remove(item);
                        await this._context.SaveChangesAsync();
                    }
                    return list;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<OrderDetail>> FinishConfirmOrder(string orderID)
        {
            try
            {
                var list = await this._context.OrderDetail.Where(x => x.OrderId.Equals(orderID)).ToListAsync();
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        item.Status = true;
                        this._context.OrderDetail.Update(item);
                        await this._context.SaveChangesAsync();
                    }
                    return list;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
