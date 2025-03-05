using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_Day5.Model;

namespace Assignment_Day5.Repository
{
    internal interface IUserRepo
    {
        public bool AddUser(User user);
       public List<User> GetAllUsers();

    }
}
