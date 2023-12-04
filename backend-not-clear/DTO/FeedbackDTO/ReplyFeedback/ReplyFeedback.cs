namespace backend_not_clear.DTO.FeedbackDTO.ReplyFeedback
{
    public class ReplyFeedback
    {
        public string FeedbackID { get; set; }
        public string UserID { get; set; }
        public string RepID { get; set; }
        public DateTime CreateDate { get; set; }
        public string FeedbackContent { get; set; }
    }
}
