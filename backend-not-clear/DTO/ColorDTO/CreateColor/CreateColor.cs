namespace backend_not_clear.DTO.ColorDTO.CreateColor
{
    public class CreateColor
    {
        public string ColorName { get; set; }
        public string? MaterialID { get; set; }
        public bool IsCustom { get; set; }
        public decimal? Price { get; set; }
    }
}
