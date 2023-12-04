namespace backend_not_clear.DTO.MaterialDTO.CreateMaterial
{
    public class CreateMaterial
    {
        public string MaterialName { get; set; }
        public string? SizeID { get; set; }
        public bool IsCustom { get; set; }
        public decimal? Price { get; set; }
    }
}
