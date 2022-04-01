using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface FeedbackService
    {
        public List<Feedback> GetFeedbacks();

        public Feedback GetFeedback(int id);

        public bool Create(Feedback feedback);
    }
}
