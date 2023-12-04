namespace backend_not_clear.DTO.OrderDetailDTO.CreateOrderDetail
{
    public class CreateOrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string? FeedbackId { get; set; }
        public int Quantity { get; set; }
    }
}
