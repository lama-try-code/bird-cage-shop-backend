namespace backend_not_clear.DTO.SizeDTO.CreateSize
{
    public class CreateSize
    {
        public string Size { get; set; }
        public string? SizeDescription { get; set; }
        public string? StyleID { get; set; }
        public bool IsCustom { get; set; }
        public decimal? Price { get; set; }
    }
}
