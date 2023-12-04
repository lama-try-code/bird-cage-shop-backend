namespace backend_not_clear.DTO.BlogDTO
{
    public class CreateBlogDTO
    {
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string userID { get; set; }
        public DateTime CreateTime { get; set; }
        public string ImageUrl { get; set; }
    }
}
