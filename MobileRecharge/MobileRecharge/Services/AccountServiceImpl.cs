using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public class AccountServiceImpl : AccountService
    {
        private DatabaseContext db;
        public AccountServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Active(string email, string token)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null)
            {
                if (account.ActiveToken == token)
                {
                    account.Status = 1;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool ChangePass(string email, string token, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null)
            {
                if (account.ResetToken == token)
                {
                    account.Password = BCrypt.Net.BCrypt.HashString(password);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Create(Account account)
        {
            try
            {
                db.Accounts.Add(account);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public Account Find(int id)
        {
            return db.Accounts.Find(id);
        }

        public dynamic FindAll()
        
        {
            return db.Accounts.Select(a => new {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                Dob = a.Dob
            }).ToList();
            
        }

        public Account GetAccountById(int id)
        {
            return db.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public bool Forgot(string email, string token)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null)
        
        {
                account.ResetToken = token;
                db.SaveChanges();
                return true;
            }
            return false;
            
        }

        public List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        public Account Login(string email, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password) && account.Status == 1)
        
        {
                    return account;
                }
            }
            return null;
            
        }

        public List<PostPaidHistory> GetPostPaidHistoryById(int accountId) {
            return db.PostPaidHistories.Where(a => a.AccountId == accountId).ToList();
        }
        public void Update(Account account)
        
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
           
        }

        public List<RechargeHistory> GetRechargeHistoryById(int accountId)
        {
            return db.RechargeHistories.Where(a => a.AccountId == accountId).ToList();
        }
    }
}
