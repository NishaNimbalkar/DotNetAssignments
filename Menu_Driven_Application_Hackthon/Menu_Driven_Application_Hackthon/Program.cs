using Menu_Driven_Application_Hackthon.Interface;
using Menu_Driven_Application_Hackthon.Model;
using Menu_Driven_Application_Hackthon.Repository;
using System;
using static Menu_Driven_Application_Hackthon.Model.Policy;

namespace Menu_Driven_Application_Hackthon
{
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
                Console.WriteLine("6. View Active Policies");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter policy id:");
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
                        bool result = policyRepository.AddPolicy(newPolicy);

                        if (result)
                        {
                            Console.WriteLine("Policy added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Policy could not be added.");
                        }

                        break;

                    case 2:
                        var policies = policyRepository.GetAllPolicies();
                        foreach(Policy policy in policies)
                        {
                            Console.WriteLine(policies);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter policy id:");
                        int policyId1 = Convert.ToInt32(Console.ReadLine());
                        var searchPolicy=policyRepository.GetPolicyById(policyId1);
                        Console.WriteLine(searchPolicy);
                        break;

                    case 4:
                        Console.WriteLine("Enter policy id you want to update:");
                        int policyId2 = Convert.ToInt32(Console.ReadLine());
                       

                        Console.WriteLine("Enter Policy Holder Name:");
                        string holderName1 = Console.ReadLine();

                        Console.WriteLine("Enter Policy Type (0 = Life, 1 = Health, 2 = Vehicle, 3 = Property):");
                        PolicyType type1 = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());
                        Console.WriteLine("Your Policy choice is " + type1);

                        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
                        DateTime startDate1 = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Enter End Date (yyyy-MM-dd):");
                        DateTime endDate1 = DateTime.Parse(Console.ReadLine());

                        Policy newPolicy1 = new Policy(policyId2, holderName1, type1, startDate1, endDate1);
                        var updatePolicy= policyRepository.UpdatePolicy(newPolicy1);
                        Console.WriteLine(updatePolicy);
                        break;

                    case 5:
                        Console.WriteLine("Enter policy id you want to delete:");
                        int policyId3 = Convert.ToInt32(Console.ReadLine());
                         policyRepository.DeletePolicyById(policyId3); 
                        Console.WriteLine();
                        break;

                    case 6:
                       
                        var activePolicies = policyRepository.GetActivePolicies();
                        if (activePolicies.Count > 0)
                        {
                            Console.WriteLine("Active Policies:");
                            foreach (var policy in activePolicies)
                            {
                                Console.WriteLine($"Policy ID: {policy.PolicyId}, Policy Holder: {policy.PolicyHolderName}, Type: {policy.PType}, Start Date: {policy.StartDate}, End Date: {policy.EndDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No active policies found.");
                        }
                        break;

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
}
