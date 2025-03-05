using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day5.Exception
{
    internal class UserAccNotExistedException : ApplicationException
    {
        public UserAccNotExistedException()
        {

        }
        public UserAccNotExistedException(string message):base(message)
        {
        }
       
    }
}
