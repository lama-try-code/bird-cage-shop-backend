

namespace backend_not_clear.DTO.VoucherUserOrderDTO.CreatyVoucherUserOrder
{
    public class CreateVoucherUserOrder
    {
        public string VoucherID { get; set; }
        public DateTime UseDate { get; set; }
        public bool Status { get; set; }
        public string OrderId { get; set; }

        public string UserId { get; set; }
    }
}
