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

        public bool Create(Feedback feedback)
        {
            try
            {
                _databaseContext.Feedbacks.Add(feedback);
                return _databaseContext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
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
