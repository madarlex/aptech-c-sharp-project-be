using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface RechargeService
    {
        public List<Recharge> GetRecharges();

        public Recharge GetRechargeById(int id);

        public List<RechargeType> GetRechargeTypes();

        public void CreateRechargeType(RechargeType rechargeType);

        public void createRecharge(Recharge recharge);

        public bool updateRecharge(Recharge recharge, int id);

        public void UpdateRechargeType(RechargeType rechargeType);

        public List<RechargeHistory> GetRechargeListByRechargeId(int rechargeId);

        public List<RechargeHistory> GetRechargeHistories();
    }
}
