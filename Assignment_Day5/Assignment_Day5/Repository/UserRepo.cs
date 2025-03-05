using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_Day5.Exception;
using Assignment_Day5.Model;

namespace Assignment_Day5.Repository
{
    internal class UserRepo : IUserRepo
    {
        List<User> users;
        public UserRepo()
        {
            users = new List<User>
            {
                new(){UserId=1,Username="Nisha",UserAccountNo=345423},
                new(){UserId=2,Username="Pratiksha",UserAccountNo=9857323}
            };
        }

        public bool AddUser(User user)
        {
            try {
                User searchresult = GetUserByAccNo(user.UserAccountNo);
                if (searchresult == null)
                {


                    if (user.UserAccountNo <= 0)
                    {
                        throw new InvalidUserNameException("User account number cannot contains 0 values ");
                    }
                    users.Add(user);
                    return true;
                }
                else
                {
                    throw new UserAccNotExistedException($"{user.UserAccountNo} already Exist");
                }

            }
            catch (InvalidUserNameException iue)
            {
                Console.WriteLine(iue.Message);
            }
            catch (UserAccNotExistedException uaex)
            {
                Console.WriteLine(uaex.Message);
            }
            return false;
            
        }
        

        public List<User> GetAllUsers()
        {
            return users;
        }
        public User GetUserByAccNo(int userAccountNo)
        {
            return users.Find(u => u.UserAccountNo == userAccountNo);
        }
        //public User GetUserByName(string name)
        //{
        //    return users.Find(u=>u.Username==name);
        //}
    }
}
