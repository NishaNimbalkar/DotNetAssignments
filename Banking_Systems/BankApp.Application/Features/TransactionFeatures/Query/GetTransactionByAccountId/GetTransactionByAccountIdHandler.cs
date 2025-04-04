using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Query.GetTransactionByAccountId
{
    public class GetTransactionByAccountIdHandler : IRequestHandler<GetTransactionByAccountId, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByAccountIdHandler(ITransactionRepository transactionRepositorys)
        {
            _transactionRepository = transactionRepositorys;  
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionByAccountId request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetTransactionByAccountId(request.id);
        }
    }

}
