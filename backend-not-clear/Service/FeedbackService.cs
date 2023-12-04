using backend_not_clear.DTO.FeedbackDTO.CreateFeedback;
using backend_not_clear.DTO.FeedbackDTO.RemoveFeedback;
using backend_not_clear.DTO.FeedbackDTO.ReplyFeedback;
using backend_not_clear.DTO.FeedbackDTO.UpdateFeedback;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class FeedbackService : IFeedback
    {
        private readonly BCS_ShopContext _context;

        public FeedbackService(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<FeedBack> CreateFeedback(CreateFeedback request)
        {
            try
            {
                FeedBack feedback = new FeedBack();
                if (request == null)
                    throw new Exception("Fail to give Feedback");
                feedback.FeedbackId = request.FeedbackID;
                feedback.Reply = null;
                feedback.UserId = request.UserID;
                feedback.DateTime = DateTime.UtcNow;
                feedback.FeedbackContent = request.FeedbackContent ?? null;
                feedback.Status = true;
                feedback.Rating = request.Rating ?? null;
                await this._context.FeedBack.AddAsync(feedback);
                await this._context.SaveChangesAsync();
                return feedback;
            }catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<FeedBack> Reply(ReplyFeedback request)
        {
            try
            {
                if (request == null) 
                    throw new Exception("Fail to Reply");
                var feedback = await this._context.FeedBack.Where(x => x.FeedbackId.Equals(request.RepID)).FirstOrDefaultAsync();
                if(feedback == null)
                    throw new Exception("Not Found Feedback To Reply");
                FeedBack reply = new FeedBack();
                reply.FeedbackId = request.FeedbackID;
                reply.UserId = request.UserID;
                reply.ReplyId = request.RepID;
                reply.FeedbackContent = request.FeedbackContent;
                reply.DateTime = DateTime.UtcNow;    
                reply.Status = true;
                await this._context.FeedBack.AddAsync(reply); 
                await this._context.SaveChangesAsync(); 
                return reply;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> RemoveFeedback(RemoveFeedback request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Fail to remove Feedback");
                var feedback = await this._context.FeedBack.Where(x => x.FeedbackId.Equals(request.BlogID)).FirstOrDefaultAsync();
                var rep = await this._context.FeedBack.Where(x => x.ReplyId.Equals(feedback.FeedbackId)).FirstOrDefaultAsync();
                if (feedback == null)
                    throw new Exception("Not found Feedback");
                //feedback.Status = false;
                if(rep != null)
                    this._context.FeedBack.Remove(rep);
                this._context.FeedBack.Remove(feedback);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> RemoveReply(RemoveReply request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Fail to remove Feedback");
                var feedback = await this._context.FeedBack.Where(x => x.ReplyId.Equals(request.RepID)).FirstOrDefaultAsync();
                if (feedback == null)
                    throw new Exception("Not found Feedback");
                this._context.FeedBack.Remove(feedback);
                await this._context.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<FeedBack> UpdateFeedback(UpdateFeedback request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Fail to update Feedback");
                var feedback = await this._context.FeedBack.Where(x => x.FeedbackId.Equals(request.BlogID)).FirstOrDefaultAsync();
                if (feedback == null)
                    throw new Exception("Not found Feedback");
                feedback.FeedbackContent = request.content ?? feedback.FeedbackContent;
                feedback.Rating = request.Rating ?? feedback.Rating;
                this._context.FeedBack.Update(feedback);
                await this._context.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<FeedBack> UpdateReply(UpdateReply request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Fail to update Feedback");
                var reply = await this._context.FeedBack.Where(x => x.ReplyId.Equals(request.RepID)).FirstOrDefaultAsync();
                if (reply == null)
                    throw new Exception("Not found Feedback");
                reply.FeedbackContent = request.content ?? reply.FeedbackContent;
                this._context.FeedBack.Update(reply);
                await this._context.SaveChangesAsync();
                return reply;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
