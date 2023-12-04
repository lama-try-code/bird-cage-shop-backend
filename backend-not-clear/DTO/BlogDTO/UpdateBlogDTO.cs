namespace backend_not_clear.DTO.BlogDTO
{
    public class UpdateBlogDTO
    {
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string BlogID { get; set; }
    }
}
