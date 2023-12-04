namespace backend_not_clear.DTO.FeedbackDTO.CreateFeedback
{
    public class CreateFeedback
    {
        public string FeedbackID { get; set; }
        public string UserID { get; set; }
        public DateTime CreateDate { get; set; }    
        public string FeedbackContent { get; set; }
        public string Rating { get; set; }
    }
}
