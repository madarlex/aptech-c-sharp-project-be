using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface PostpaidService
    {
        public List<PostPaid> GetPostpaids();

        public PostPaid GetPostpaidById(int id);


        public void createPostpaid(PostPaid postpaid);

        public bool updatePostpaid(PostPaid postpaid, int id);

        public List<PostPaidHistory> GetPostPaidHistories();

        public List<PostPaidHistory> GetPostPaidHistoriesByPostpaidId(int postpaidId);
        public dynamic FindAll();
        public bool UpdatePostPaidHistory(string id);
        public bool CreatePostPaidHistory(PostPaidHistory postPaidHistory);
        public PostPaidHistory Find(int id);
    }
}
