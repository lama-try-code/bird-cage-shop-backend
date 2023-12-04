using backend_not_clear.DTO.OrderDetailDTO;
using backend_not_clear.DTO.OrderDetailDTO.CreateOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.RemoveOrderDetail;
using backend_not_clear.DTO.OrderDetailDTO.UpdateOrderDetail;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IOrderDetail
    {
        public Task<OrderDetail> CreateNewOrderDetail(CreateOrderDetail order);
        public Task<OrderDetail> UpdateOrderDetail(UpdateOrderDetail order);
        public Task<OrderDetail> RemoveOrderDetail(RemoveOrderDetail order);
        public Task<List<OrderDetail>> RemoveAllDetail(string orderID);
        public Task<List<OrderDetail>> FinishConfirmOrder(string orderID);
    }
}
