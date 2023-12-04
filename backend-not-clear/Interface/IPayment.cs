using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IPayment
    {
        Task<Payment> createPayment(string OrderId);
        Task<Payment> GetPayment(string OrderId);
        Task<Payment> UpdatePaymentForCOD(string paymentId);
    }
}
