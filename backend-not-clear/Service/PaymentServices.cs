using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class PaymentServices : IPayment
    {
        private readonly BCS_ShopContext _context;
        public PaymentServices(BCS_ShopContext context)
        {
            _context = context;
        }
        public async Task<Payment> createPayment(string OrderId)
        {
            try
            {
                var payment = new Payment();
                var order = await this._context.Order.Where(x => x.OrderId.Equals(OrderId))
                                                     .FirstOrDefaultAsync();
                if (order != null)
                {
                    payment.PaymentId = "p" + Guid.NewGuid().ToString().Substring(0, 8);
                    payment.OrderId = order.OrderId;
                    payment.CreateDate = DateTime.Now;
                    payment.Amout = order.Total;
                    payment.Status = false;
                    await this._context.Payment.AddAsync(payment);
                    await this._context.SaveChangesAsync();
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Payment> GetPayment(string OrderId)
        {
            try
            {
                var payment = await this._context.Payment.Where(x => x.OrderId.Equals(OrderId))
                                .FirstOrDefaultAsync();
                if (payment != null)
                {
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Payment> UpdatePaymentForCOD(string paymentId)
        {
            try
            {
                var payment = await this._context.Payment.Where(x => x.PaymentId.Equals(paymentId))
                                                         .FirstOrDefaultAsync();
                if (payment != null)
                {
                    payment.Status = true;
                    this._context.Payment.Update(payment);
                    await this._context.SaveChangesAsync();
                    var order = await this._context.Order.Where(x => x.OrderId.Equals(payment.OrderId)).FirstOrDefaultAsync();
                    if (order != null)
                    {
                        order.Status = true;
                        this._context.Order.Update(order);
                        await this._context.SaveChangesAsync();
                    }
                    var orderDetail = await this._context.OrderDetail.Where(x => x.OrderId.Equals(payment.OrderId)).ToListAsync();
                    if (orderDetail != null)
                    {
                        foreach(var item in orderDetail)
                        {
                            item.Status = true;
                            this._context.OrderDetail.Update(item);
                            await this._context.SaveChangesAsync();
                        }
                    }
                    return payment;
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
