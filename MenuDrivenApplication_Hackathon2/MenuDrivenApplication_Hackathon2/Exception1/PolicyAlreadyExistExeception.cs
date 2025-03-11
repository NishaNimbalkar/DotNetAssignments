using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDrivenApplication_Hackathon2.Exception1
{
    internal class PolicyAlreadyExistExeception:ApplicationException
    {
        public PolicyAlreadyExistExeception()
        {

        }
        public PolicyAlreadyExistExeception(string message):base(message)
        {

        }
    }
}
