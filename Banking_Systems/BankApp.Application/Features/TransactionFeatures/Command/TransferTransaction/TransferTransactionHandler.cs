using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Command.TransferTransaction
{
    public class TransferTransactionHandler : IRequestHandler<TransferTransactionCommand, int>
    {
        readonly ITransactionRepository _transactionRepository;
        public TransferTransactionHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Task<int> Handle(TransferTransactionCommand request, CancellationToken cancellationToken)
        {
            return _transactionRepository.TransferAnotherAccountAccountNumber(request.accountId, request.TransferModel);

        }
    }
}
