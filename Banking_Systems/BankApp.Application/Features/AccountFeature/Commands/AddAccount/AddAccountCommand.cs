using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using BankApp.Domain.Enum;
using MediatR;
using BankApp.Application.Models;
using BankApp.Application.Models.Accounts;

namespace BankApp.Application.Features.AccountFeature.Commands.AddAccount
{
    public record AddAccountCommand(string userId,AddAccountRequest account):IRequest<Account>
    {
        

      
    }
}
