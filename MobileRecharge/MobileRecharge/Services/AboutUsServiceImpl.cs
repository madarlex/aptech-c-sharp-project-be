using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public class AboutUsServiceImpl : AboutUsService
    {
        private readonly DatabaseContext databaseContext;
        public AboutUsServiceImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<AboutU> GetAll()
        {
            return databaseContext.AboutUs.ToList();    
        }

        public void GetContent(string content)
        {
            var dbContent = databaseContext.AboutUs.FirstOrDefault();
            if (dbContent == null)
            {
                var aboutus = new AboutU();
                aboutus.Maincontent = content;
                databaseContext.AboutUs.Add(aboutus);
                databaseContext.SaveChanges();
            } else
            {
                UpdateContent(content);
            }
        }

        public AboutU ShowContentById(int id)
        {
            return databaseContext.AboutUs.FirstOrDefault(a => a.Id == id);
        }

        public void UpdateContent(string content)
        {
            var dbContent = databaseContext.AboutUs.FirstOrDefault();
            dbContent.Maincontent = content;
            databaseContext.SaveChanges();
        }
    }
}
