using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Driven_Application_Hackthon.Exception
{
    internal class PolicyIdAlreadyExistException : ApplicationException
    {
        public PolicyIdAlreadyExistException()
        {

        }
        public PolicyIdAlreadyExistException
            (string message) : base(message)
        {
        }
    }
}
