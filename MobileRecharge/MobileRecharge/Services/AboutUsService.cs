using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface AboutUsService
    {
        public void GetContent(string content);

        public void UpdateContent(string content);

        public AboutU ShowContentById(int id);
        public List<AboutU> GetAll();
    }
}
