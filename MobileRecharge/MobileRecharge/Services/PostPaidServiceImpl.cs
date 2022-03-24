using MobileRecharge.Models;
using MobileRecharge.Helpers;

namespace MobileRecharge.Services
{
    public class PostPaidServiceImpl : PostPaidService
    {
        private DatabaseContext db;
        public PostPaidServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool CreatePostPaidHistory(PostPaidHistory postPaidHistory)
        {

            db.PostPaidHistories.Add(postPaidHistory);
            if (db.SaveChanges() > 0)
            {
                EmailHelper.SendEmail("c2003lcodedao@gmail.com", "Prepaid Confirmation", "Code: " + postPaidHistory.Code.ToString());
                return true;
            }
            return false;
        }

        public PostPaidHistory Find(int id)
        {
            return db.PostPaidHistories.Find(id);
        }

        public List<PostPaid> FindAll()
        {
            return db.PostPaids.ToList();
        }

        public bool UpdatePostPaidHistory(string id)
        {
            var selectedPostPaidHistory = db.PostPaidHistories.Where(p => p.AccountId == Int32.Parse(id)).OrderByDescending(p => p.Id).FirstOrDefault();
            if (selectedPostPaidHistory != null)
            {
                selectedPostPaidHistory.Status = 1;
                db.Entry(selectedPostPaidHistory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            } 
            else
            {
                return false;
            }
        }
    }
}
