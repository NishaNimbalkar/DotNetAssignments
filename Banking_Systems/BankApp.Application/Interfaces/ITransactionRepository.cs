using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Models.Transactions;
using BankApp.Domain;

namespace BankApp.Application.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAllTransaction();
        public Task<Transaction> GetTransactionById(int id);
        public Task<Transaction> AddTransactionAsync(int id,Addtransaction transaction);


        Task<int> TransferAnotherAccountAccountNumber(int accountId, TransactionTransfer transactionTransfer);

        public Task<IEnumerable<Transaction>> GetTransactionByAccountId(int id);
    }
}
