using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface PostPaidService
    {
        public List<PostPaid> FindAll();
        public bool UpdatePostPaidHistory(string id);
        public bool CreatePostPaidHistory(PostPaidHistory postPaidHistory);
        public PostPaidHistory Find(int id);
    }


}
