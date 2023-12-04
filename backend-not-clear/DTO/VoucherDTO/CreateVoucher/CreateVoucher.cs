namespace backend_not_clear.DTO.VoucherDTO.CreatyVoucher
{
    public class CreateVoucher
    {
        public string VoucherName { get; set; }
        public string Description { get; set; }
        public string Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
