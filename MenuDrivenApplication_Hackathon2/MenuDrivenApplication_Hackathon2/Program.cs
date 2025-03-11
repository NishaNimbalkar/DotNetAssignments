using MenuDrivenApplication_Hackathon2.Model;
using MenuDrivenApplication_Hackathon2.Repository;
using static MenuDrivenApplication_Hackathon2.Model.Policy;


internal class Program
{
    private static void Main(string[] args)
    {
        IPolicyRepository policyRepository = new PolicyRepository();

        while (true)
        {
            Console.WriteLine("\nInsurance Policy Management");
            Console.WriteLine("1. Add Policy");
            Console.WriteLine("2. View All Policies");
            Console.WriteLine("3. Search Policy by ID");
            Console.WriteLine("4. Update Policy");
            Console.WriteLine("5. Delete Policy");
           
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:

                    Console.WriteLine("Enter Policy Id");
                    int policyId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Policy Holder Name:");
                    string holderName = Console.ReadLine();

                    Console.WriteLine("Enter Policy Type (0 = Life, 1 = Health, 2 = Vehicle, 3 = Property):");
                    PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());
                    Console.WriteLine("Your Policy choice is " + type);

                    Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter End Date (yyyy-MM-dd):");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    Policy newPolicy = new Policy(policyId, holderName, type, startDate, endDate);
                    int result = policyRepository.AddPolicy(newPolicy);

                    if (result==1)
                    {
                        Console.WriteLine("Policy added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Policy could not be added.");
                    }

                    break;

                case 2:
                    List<Policy> policies = policyRepository.GetAllPolicies();
                    foreach (Policy policy in policies)
                    {
                        Console.WriteLine(policy);
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter policy id:");
                    int policyId1 = Convert.ToInt32(Console.ReadLine());
                    var searchPolicy = policyRepository.GetPolicyById(policyId1);
                    Console.WriteLine(searchPolicy);
                    break;

                case 4:
                    Console.WriteLine("Enter policy id you want to update:");
                    int policyId2 = Convert.ToInt32(Console.ReadLine());


                    Console.WriteLine("Enter Policy Holder Name:");
                    string holderName1 = Console.ReadLine();

                    Console.WriteLine("Enter Policy Type (0 = Life, 1 = Health, 2 = Vehicle, 3 = Property):");
                    PolicyType type1 = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());



                    //Console.WriteLine("Your Policy choice is " + type1);

                    Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
                    DateTime startDate1 = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter End Date (yyyy-MM-dd):");
                    DateTime endDate1 = DateTime.Parse(Console.ReadLine());

                    Policy newPolicy1 = new Policy(policyId2, holderName1, type1, startDate1, endDate1);
                    var updatePolicy = policyRepository.UpdatePolicy(newPolicy1);
                    if (updatePolicy!=null)
                    {
                        Console.WriteLine("Policy Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                    break;

                case 5:
                    Console.WriteLine("Enter policy id you want to delete:");
                    int policyId3 = Convert.ToInt32(Console.ReadLine());
                    policyRepository.DeletePolicy(policyId3);
                    Console.WriteLine();
                    break;




                case 7:
                    Console.WriteLine("Exiting the Application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


}
    