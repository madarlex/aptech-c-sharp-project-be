using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public class FeedbackServiceImpl : FeedbackService
    {
        private readonly DatabaseContext _databaseContext;
        public FeedbackServiceImpl(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Feedback GetFeedback(int id)
        {
            if(_databaseContext != null)
            {
                return _databaseContext.Feedbacks.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public List<Feedback> GetFeedbacks()
        {
            return _databaseContext.Feedbacks.ToList();
        }
    }
}
