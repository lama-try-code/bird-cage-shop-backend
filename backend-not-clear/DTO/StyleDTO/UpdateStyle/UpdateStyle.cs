namespace backend_not_clear.DTO.StyleDTO.UpdateStyle
{
    public class UpdateStyle
    {
        public string StyleID { get; set; }
        public string StyleName { get; set; }
        public string StyleDescription { get; set; }
        public bool Status { get; set; }
        public bool IsCustom { get; set; }
        public decimal? Price { get; set; }
    }
}
