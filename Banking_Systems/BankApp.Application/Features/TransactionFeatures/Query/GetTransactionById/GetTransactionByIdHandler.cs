using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Query.GetTransactionById
{
    internal class GetTransactionByIdHandler : IRequestHandler<GetTransactionById, Transaction>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByIdHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository; 
        }
        public async Task<Transaction> Handle(GetTransactionById request, CancellationToken cancellationToken)
        {
            var getTransaction = await _transactionRepository.GetTransactionById(request.id);
            return getTransaction;
        }
    }
}
