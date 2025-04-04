using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Exception;
using BankApp.Application.Interfaces;
using BankApp.Application.Models.Accounts;
using BankApp.Domain;
using BankApp.Domain.Enum;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Command.AddTransaction
{
    public class AddTransactionHandler : IRequestHandler<AddTransaction, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public AddTransactionHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Transaction> Handle(AddTransaction request, CancellationToken cancellationToken)
        {


           

            // Add transaction
            var addedTransaction = await _transactionRepository.AddTransactionAsync(request.id, request.transaction);

            return addedTransaction;
        }
    }

}
