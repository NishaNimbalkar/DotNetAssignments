using MediatR;
using BankApp.Domain;
using BankApp.Domain.Enum;

namespace BankApp.Application.Features.AccountFeature.Commands.UpdateCommand
{
    public class UpdateCommand : IRequest<Account>
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
