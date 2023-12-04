using backend_not_clear.DTO.OrderDTO;
using backend_not_clear.DTO.OrderDTO.CreateOrder;
using backend_not_clear.DTO.OrderDTO.CreateOrderCustom;
using backend_not_clear.DTO.OrderDTO.ReturnOrdersByMonth;
using backend_not_clear.DTO.OrderDTO.SearchOrder;
using backend_not_clear.DTO.OrderDTO.UpdateOrder;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IOrder
    {
        public Task<List<Order>> GetOrderNotFinishedForUser(SearchOrder search);
        public Task<List<Order>> GetCustomOrder(SearchOrder search);
        public Task<List<Order>> GetOrderFinishedForUser(SearchOrder search);
        public Task<List<Order>> GetAll();
        public Task<Order> CreateNew(CreateOrder order);
        public Task<Order> CreateNewCustomOrder(CreateCustomOrder order);
        public Task<Order> FinishPayment(string OrderID);
        public Task<Order> UpdateOrder(UpdateOrder order);
        public Task<List<ReturnOrdersByMonth>> getOrdersByMonth();
        public Task<Int32> countAllOrder();
        public Task<List<Order>> GetOrderToConfirm();
        public Task<List<Order>> GetCustomOrderToConfirm();
        public Task<Order> RemoveOrder(string OrderId);
    }
}
