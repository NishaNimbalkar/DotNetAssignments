using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using BankApp.Domain;

namespace BankApp.Application.Interfaces
{
    public interface IAccountRepository
    {

        public Task<IEnumerable<Account>> GetAllAccounts();
        public Task<Account> GetAccountById(int id);
        public Task<Account> AddAccountAsync(Account account);
        Task<bool> DeleteAccount(int id);
        Task<Account> UpdateAccount(Account account);
        Task<IEnumerable<Account>> GetAccountByUserId(string id);
    }
}
