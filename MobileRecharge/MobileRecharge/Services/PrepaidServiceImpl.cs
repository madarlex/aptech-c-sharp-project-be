using MobileRecharge.Models;
using System.Diagnostics;
using MobileRecharge.Helpers;

namespace MobileRecharge.Services
{
    public class PrepaidServiceImpl : PrepaidService
    {
        private DatabaseContext db;
        public PrepaidServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool CreateRechargeHistory(RechargeHistory rechargeHistory)
        {

            db.RechargeHistories.Add(rechargeHistory);
            if (db.SaveChanges() > 0)
            {
                EmailHelper.SendEmail("c2003lcodedao@gmail.com", "Prepaid Confirmation", "Code: " + rechargeHistory.Code.ToString());
                return true;
            }
            return false;
        }

        public RechargeHistory Find(int id)
        {
            return db.RechargeHistories.Find(id);
        }

        public List<Recharge> FindAll()
        {
            return db.Recharges.ToList();
        }

        public List<Recharge> FindAllNormal()
        {
            return db.Recharges.Where(p => p.RechargeTypeId == 1).ToList();
        }

        public List<Recharge> FindAllSpecial()
        {
            return db.Recharges.Where(p => p.RechargeTypeId == 2).ToList();
        }

        public bool UpdateRechargeHistory(string id)
        {

            var selectedRechargeHistory = db.RechargeHistories.Where(p => p.AccountId == Int32.Parse(id)).OrderByDescending(p => p.Id).FirstOrDefault();
            if (selectedRechargeHistory != null)
            {
                selectedRechargeHistory.Status = 1;
                db.Entry(selectedRechargeHistory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            } 
            else
            {
                return false;
            }
        }

    }
}
