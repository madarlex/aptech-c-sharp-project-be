﻿using MobileRecharge.Models;

namespace MobileRecharge.Services
{
    public interface AccountService
    {
        public dynamic FindAll();

        public Account Find(int id);

        public bool Create(Account account);

        public bool Active(string email, string token);

        public Account Login(string username, string password);

        public void Update(Account account);

        public bool Forgot(string email, string token);

        public bool ChangePass(string email, string token, string password);
        public List<Account> GetAllAccounts();
        public Account GetAccountById(int id);
        public List<RechargeHistory> GetRechargeHistoryById(int accountId);
        public List<PostPaidHistory> GetPostPaidHistoryById(int accountId);

        public bool CheckUniqueEmail(string email);
    }
}
