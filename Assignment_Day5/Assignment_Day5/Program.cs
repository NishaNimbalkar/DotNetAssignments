using Assignment_Day5.Model;
using Assignment_Day5.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        IUserRepo userRepo = new UserRepo();
       List<User>allUsers= userRepo.GetAllUsers();
        //foreach (User user in allUsers)
        //{

        //    Console.WriteLine(user);
        //}
        //User user1 = new User() { UserId = 3, Username = "Shiavn", UserAccountNo = 9857323 };
        //bool searchresultdata = userRepo.AddUser(user1);
        //if (searchresultdata == true)
        //{
        //    Console.WriteLine("User added successfully!!!");
        //}

        //else
        //{
        //    Console.WriteLine("Not Added");
        //}

        User user2 = new User() { UserId = 3, Username = "Shiavn", UserAccountNo = 0 };
        bool addUserResult = userRepo.AddUser(user2);
        if (addUserResult == true)
        {
            Console.WriteLine("User added successfully");
        }

        else
        {
            Console.WriteLine("User could not be added due to invalid account number");
        }


        //

    }
}