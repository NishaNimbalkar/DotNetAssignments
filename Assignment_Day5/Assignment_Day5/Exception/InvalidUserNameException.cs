using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day5.Exception
{
    internal class InvalidUserNameException : ApplicationException
    {

        public InvalidUserNameException()
        {

        }
         public InvalidUserNameException(string message) : base(message)
        {
        }
    }
}
