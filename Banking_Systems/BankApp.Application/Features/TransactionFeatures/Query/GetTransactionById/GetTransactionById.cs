using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Query.GetTransactionById
{
    public record class GetTransactionById(int id):IRequest<Transaction>
    {
    }
}
