using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BankApp.Application.Interfaces;
using BankApp.Domain;

namespace BankApp.Application.Features.AccountFeature.Commands.UpdateCommand
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountById(request.Id);

            if (account == null)
                throw new KeyNotFoundException($"Account with ID {request.Id} not found.");

            account.Balance = request.Balance;
            account.AccountType = request.AccountType;

            await _accountRepository.UpdateAccount(account);

            return account;
        }
    }
}
