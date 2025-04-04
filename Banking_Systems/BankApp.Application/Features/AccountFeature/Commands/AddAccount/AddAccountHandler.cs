using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Commands.AddAccount
{
    public class AddAccountHandler : IRequestHandler<AddAccountCommand,Account>
    {
        readonly IAccountRepository _accountRepository;
        public AddAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account();
            account.UserId = request.userId;
            account.Balance = request.account.Balance;
            account.CreatedDate = request.account.CreatedDate;
            account.AccountNumber = request.account.AccountNumber;
            account.AccountType = request.account.AccountType;
            var accounts = await _accountRepository.AddAccountAsync(account);
            return accounts;
        }
    }
}
