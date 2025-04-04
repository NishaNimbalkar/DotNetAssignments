using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Models.Transactions;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.TransactionFeatures.Command.AddTransaction
{
   public record  AddTransaction(int id, Addtransaction transaction
       ) :IRequest<Transaction>
    {

    }
   
}
