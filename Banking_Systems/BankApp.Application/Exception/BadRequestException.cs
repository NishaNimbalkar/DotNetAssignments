using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.Exception
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string msg) : base(msg)
        {

        }
    }
}
