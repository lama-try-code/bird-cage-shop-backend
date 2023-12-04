namespace backend_not_clear.DTO.BirdDTO.UpdateBird
{
    public class UpdateBird
    {
        public string BirdID { get; set; }
        public string BirdName { get; set; }
        public string BirdDescription { get; set; }
        public string? BirdTypes { get; set; }
        public string? BirdSizes { get; set; }
        public bool BirdStatus { get; set; }
    }
}
