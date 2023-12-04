namespace backend_not_clear.DTO.OrderDetailDTO.UpdateOrderDetail
{
    public class UpdateOrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string? FeedbackId { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
