using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Features.TransactionFeatures.Query.GetTransactionByAccountId;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAccountByUserId
{
    internal class GetAccountByUseridHandler : IRequestHandler<GetAccountByUserIdCommand, IEnumerable<Account>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByUseridHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Account>> Handle(GetAccountByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountByUserId(request.Id);
        }
    }
}
