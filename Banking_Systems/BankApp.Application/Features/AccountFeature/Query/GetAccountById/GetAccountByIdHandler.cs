using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAccountById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountById, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;  // ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Account> Handle(GetAccountById request, CancellationToken cancellationToken)
        {
          var accountFindStatus=  await _accountRepository.GetAccountById(request.Id);
            return accountFindStatus;

        }
    }
    }

