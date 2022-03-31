using MobileRecharge.Models;
using System.Diagnostics;

namespace MobileRecharge.Services
{
    public class PostpaidServiceImpl : PostpaidService
    {
        private readonly DatabaseContext databaseContext;
        public PostpaidServiceImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void createPostpaid(PostPaid postpaid)
        {
            databaseContext.PostPaids.Add(postpaid);
            databaseContext.SaveChanges();
        }

        public PostPaid GetPostpaidById(int id)
        {
            var postpaid = databaseContext.PostPaids.FirstOrDefault(p => p.Id == id);
            return postpaid;
        }

        public List<PostPaidHistory> GetPostPaidHistories()
        {
            return databaseContext.PostPaidHistories.ToList();
        }

        public List<PostPaidHistory> GetPostPaidHistoriesByPostpaidId(int postpaidId)
        {
            return databaseContext.PostPaidHistories.Where(p => p.PostPaidId == postpaidId).ToList();
        }

        public List<PostPaid> GetPostpaids()
        {
            return databaseContext.PostPaids.ToList();  
        }

        public bool updatePostpaid(PostPaid postpaid, int id)
        {
            var dbPostpaid = databaseContext.PostPaids.FirstOrDefault(p => p.Id == id); 
            if (dbPostpaid == null)
            {
                return false;
            }
            else
            {
                dbPostpaid.Name = postpaid.Name;
                dbPostpaid.Description = postpaid.Description;
                dbPostpaid.Price = postpaid.Price;
                dbPostpaid.Status = postpaid.Status;
                databaseContext.SaveChanges();
                return true;
            }
        }

        public bool CreatePostPaidHistory(PostPaidHistory postPaidHistory)
        {

            db.PostPaidHistories.Add(postPaidHistory);
            if (db.SaveChanges() > 0)
            {
                EmailHelper.SendEmail("c2003lcodedao@gmail.com", "PostPaid Confirmation", "Code: " + postPaidHistory.Code.ToString());
                return true;
            }
            return false;
        }

        public PostPaidHistory Find(int id)
        {
            return db.PostPaidHistories.Find(id);
        }

        public dynamic FindAll()
        {
            return db.PostPaids.Select(p => new SupPostPaid
            {
                Id = p.Id,
                Price = p.Price,
                Status = p.Status,
                Description = p.Description,
                Name = p.Name,
            }).ToList();
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
