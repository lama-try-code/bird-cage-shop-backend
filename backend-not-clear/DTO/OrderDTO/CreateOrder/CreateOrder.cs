namespace backend_not_clear.DTO.OrderDTO.CreateOrder
{
    public class CreateOrder
    {
        public string UserID { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Total { get; set; }
    }
}
