using BusinessObjects.Models;
using DataAccess.Dto.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        //Using Singleton Pattern
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new AccountDAO();
                }
                return instance;
            }
        }

        public bool Login(string email, string password)
        {
            using (var context = new xDbContext())
            {
                var account = context.Accounts.FirstOrDefault(acc => acc.Email == email && acc.Password == password);

                return account != null;
            }
        }

        public void AddAccount(Account account)
        {
            using (var context = new xDbContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public void UpdateAccount(Account account)
        {
            using (var context = new xDbContext())
            {
                context.Accounts.Update(account);
                context.SaveChanges();
            }
        }

        public void DeleteAccount(int accountId)
        {
            using (var context = new xDbContext())
            {
                var account = context.Accounts.FirstOrDefault(a => a.Id == accountId);
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
            }
        }
    }
}
