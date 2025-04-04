using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAccountById
{
    public record GetAccountById(int Id):IRequest<Account>;
    
    }

