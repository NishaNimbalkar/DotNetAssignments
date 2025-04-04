using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Query.GetAllTransaction
{
    public class GetAllTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetAllTransaction, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository = transactionRepository;
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransaction request, CancellationToken cancellationToken)
        {
            var allTransaction = await _transactionRepository.GetAllTransaction();
            return allTransaction;
        }
    }
}
