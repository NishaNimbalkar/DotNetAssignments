using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BankApp.Application.Exception;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using BankApp.Domain.Enum;
using BankApp.Infrastrucure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Infrastrucure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly BankDbContext _bankDbContext;

        public AccountRepository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<Account> AddAccountAsync(Account account)
        {

            // Save updated account balance


            await _bankDbContext.Accounts.AddAsync(account);
            await _bankDbContext.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await _bankDbContext.Accounts.FindAsync(id);

            if (account == null)
            {
                return false;  // Account not found, return false
            }

            _bankDbContext.Accounts.Remove(account);
            await _bankDbContext.SaveChangesAsync();

            return true;  // Successfully deleted
        }





        public async Task<Account> GetAccountById(int id)
        {
            return await _bankDbContext.Accounts
                .FirstOrDefaultAsync(a => a.id == id);
        }
        public async Task<IEnumerable<Account>>GetAccountByUserId(string id)
        {
           
            return await _bankDbContext.Accounts.Where(a => a.UserId==id).ToListAsync();


        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _bankDbContext.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _bankDbContext.Accounts.Update(account);
            await _bankDbContext.SaveChangesAsync();
            return account;
        }
        
    }
}
