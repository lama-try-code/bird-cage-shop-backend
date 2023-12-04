namespace backend_not_clear.DTO.OrderDTO.CreateOrderCustom
{
    public class CreateCustomOrder
    {
        public string UserID { get; set; }
        public string ProductCustomId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Total { get; set; }
    }
}
