using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Commands.DeleteAccount
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccount, bool>
    {
        readonly IAccountRepository _accountRepository;
        public DeleteAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(DeleteAccount request, CancellationToken cancellationToken)
        {
            var accountFindStatus = await _accountRepository.GetAccountById(request.Id);

            //if (accountFindStatus == null)
            //{
            //    throw new NotFoundException($"Account with Id {request.id} not found");
            //}

            return await _accountRepository.DeleteAccount(accountFindStatus.id);
        }

    }
}
