using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Models.Transactions;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Command.TransferTransaction
{
    public record TransferTransactionCommand(int accountId, TransactionTransfer TransferModel) :IRequest<int>
    {
    }
}
