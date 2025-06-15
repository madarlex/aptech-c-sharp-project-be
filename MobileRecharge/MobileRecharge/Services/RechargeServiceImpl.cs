using MobileRecharge.Models;
using System.Diagnostics;

namespace MobileRecharge.Services
{
    public class RechargeServiceImpl : RechargeService
    {
        private readonly DatabaseContext databaseContext;
        public RechargeServiceImpl(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public void createRecharge(Recharge recharge)
        {
            databaseContext.Recharges.Add(recharge);
            databaseContext.SaveChanges();
        }

        public void CreateRechargeType(RechargeType rechargeType)
        {
            databaseContext.RechargeTypes.Add(rechargeType);
            databaseContext.SaveChanges();
        }




        public Recharge GetRechargeById(int id)
        { 
            var recharge =  databaseContext.Recharges.FirstOrDefault(r => r.Id == id);
            return recharge;
        }

        public List<RechargeHistory> GetRechargeHistories()
        {
            return databaseContext.RechargeHistories.ToList();
        }

        public List<RechargeHistory> GetRechargeListByRechargeId(int rechargeId)
        {
            return databaseContext.RechargeHistories.Where(r => r.RechargeId == rechargeId).ToList();   
        }

        public List<Recharge> GetRecharges()
        {
            return databaseContext.Recharges.ToList();
        }

        public List<RechargeType> GetRechargeTypes()
        {
            return databaseContext.RechargeTypes.ToList();
        }

        public bool updateRecharge(Recharge recharge, int id)
        {
            var dbRecharge = databaseContext.Recharges.FirstOrDefault(r => r.Id == id);
            if (dbRecharge == null)
            {
                return false;
            } else
            {
                dbRecharge.Name = recharge.Name;
                dbRecharge.Description = recharge.Description;
                dbRecharge.Price = recharge.Price;
                dbRecharge.Status = recharge.Status;
                dbRecharge.Minutes = recharge.Minutes;
                dbRecharge.Data = recharge.Data;
                dbRecharge.RechargeTypeId = recharge.RechargeTypeId;
                
                databaseContext.SaveChanges();
                return true;
            }
        }

        public void UpdateRechargeType(RechargeType rechargeType)
        {
            databaseContext.RechargeTypes.Update(rechargeType);
            databaseContext.SaveChanges();
        }
    }
}
