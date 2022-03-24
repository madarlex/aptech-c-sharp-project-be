using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface PrepaidService
    {
        public List<Recharge> FindAll();
        public List<Recharge> FindAllNormal();
        public List<Recharge> FindAllSpecial();
        public bool UpdateRechargeHistory(string id);
        public bool CreateRechargeHistory(RechargeHistory rechargeHistory);
        public RechargeHistory Find(int id);
    }


}
