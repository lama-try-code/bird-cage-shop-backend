namespace backend_not_clear.DTO.StyleDTO.CreateStyle
{
    public class CreateStyle
    {
        public string StyleName { get; set; }
        public string StyleDescription { get; set; }
        public bool Status { get; set; }
        public bool IsCustom { get; set; }
        public decimal? Price { get; set; }
    }
}
