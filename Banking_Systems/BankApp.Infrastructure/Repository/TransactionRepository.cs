using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Exception;
using BankApp.Application.Interfaces;
using BankApp.Application.Models.Transactions;
using BankApp.Domain;
using BankApp.Domain.Enum;
using BankApp.Infrastrucure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BankApp.Infrastrucure.Repository
{
    internal class TransactionRepository : ITransactionRepository
    {
        
          readonly BankDbContext _bankDbContext;
        public TransactionRepository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;  
        }
        public async Task<IEnumerable<Transaction>> GetAllTransaction()
        {
            return await _bankDbContext.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByAccountId(int id)
        {
            var getAccountById = await _bankDbContext.Transactions.Include(t=>t.Account).Where(a => a.AccountId == id).ToListAsync();
            return getAccountById;

        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _bankDbContext.Transactions.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<int> TransferAnotherAccountAccountNumber(int accountId, TransactionTransfer transactionTransfer)
        {

            var transaction = new Transaction
            {
                AccountId = accountId,
                Type = TransactionType.Debit,
                Amount = transactionTransfer.Amount,
                Description = $"Transfer to {transactionTransfer.AccountNumber}",


            };
            var account = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.id == accountId);
            
                if (account == null)
                {
                    throw new NotFoundException($"Account Of id={accountId} not found!!!");
                }
                if (account.Balance < transaction.Amount)
                {
                    throw new InsufficientBalance("Insufficient Balance!!!!");

                }
          
            var accountData = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transactionTransfer.AccountNumber);
            if (accountData == null)
            {
                throw new NotFoundException($"Account Of id={accountId} not found!!!");
            }

            account.Balance -= transaction.Amount;
            accountData.Balance += transaction.Amount;


            var toTransaction = new Transaction
            {
                AccountId = accountData.id,
                Type = TransactionType.credit,

                Amount = transactionTransfer.Amount,
                Description = $"Transfer From {account.AccountNumber}",



            };
            await _bankDbContext.AddAsync(toTransaction);

            await _bankDbContext.AddAsync(transaction);
            return await _bankDbContext.SaveChangesAsync();

        }

        async Task<Transaction> ITransactionRepository.AddTransactionAsync(int Id, Addtransaction transactionTransfer)
        {
            var transaction = new Transaction
            {
                AccountId = Id,
                Type = TransactionType.Debit,
                Amount = transactionTransfer.Amount,
                Description = transactionTransfer.Description


            };
            var account = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.id == Id);
            if (account == null)
            {
                throw new NotFoundException($"Account  id={Id} not found");
            }
            if (account.Balance < transaction.Amount)
            {
                throw new InsufficientBalance("Insufficient Balance");

            }
            account.Balance -= transaction.Amount;

            await _bankDbContext.AddAsync(transaction);
            await _bankDbContext.SaveChangesAsync();
            return transaction;

        }
    }
}
