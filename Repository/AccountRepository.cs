using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public void DeleteAccount(int accountId) => AccountDAO.Instance.DeleteAccount(accountId);

        public bool Login(string email, string password) => AccountDAO.Instance.Login(email, password);

        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
