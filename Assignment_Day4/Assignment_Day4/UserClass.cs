using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day4
{
    internal class UserClass
    {
        public static int userId=0;

        public UserClass()
        {
            userId++;
          
        }
        public static int getUserId()
        {
            return userId;
        }
       
    }
}
