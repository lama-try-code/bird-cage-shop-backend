using backend_not_clear.DTO.FeedbackDTO.CreateFeedback;
using backend_not_clear.DTO.FeedbackDTO.RemoveFeedback;
using backend_not_clear.DTO.FeedbackDTO.ReplyFeedback;
using backend_not_clear.DTO.FeedbackDTO.UpdateFeedback;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IFeedback
    {
        public Task<FeedBack> CreateFeedback(CreateFeedback request);
        public Task<FeedBack> Reply(ReplyFeedback request);
        public Task<FeedBack> UpdateFeedback(UpdateFeedback request);
        public Task<FeedBack> UpdateReply(UpdateReply request);
        public Task<bool> RemoveFeedback(RemoveFeedback request);
        public Task<bool> RemoveReply(RemoveReply request);
    }
}
