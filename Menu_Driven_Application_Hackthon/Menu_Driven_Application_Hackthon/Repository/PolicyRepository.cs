using Menu_Driven_Application_Hackthon.Exception;
using Menu_Driven_Application_Hackthon.Interface;
using Menu_Driven_Application_Hackthon.Model;
using System;
using System.Collections.Generic;

namespace Menu_Driven_Application_Hackthon.Repository
{
    internal class PolicyRepository : IPolicyRepository
    {
        private List<Policy> policies;

        public PolicyRepository()
        {
            policies = new List<Policy>();
        }

        // Add a New Policy
        public bool AddPolicy(Policy policy)
        {
            try
            {
                Policy searchresult = GetPolicyById(policy.PolicyId);
                if (searchresult == null)
                {
                    policies.Add(policy);
                    return true;
                }
                else
                {
                    //throw exception PolicyAlreadyExistsException
                    throw new PolicyIdAlreadyExistException($"{policy.PolicyId} already Exists");

                }
            }
            catch (PolicyIdAlreadyExistException paex)
            {
                Console.WriteLine(paex.Message);
            }
            return false;

        }

        // View All Policies
        public List<Policy> GetAllPolicies()
        {
            return policies;
        }

        // Search Policy by ID
        public Policy GetPolicyById(int policyId)
        {
            return policies.Find(p => p.PolicyId == policyId);
        }

        // Update Policy Details
        public Policy UpdatePolicy(Policy updatedPolicy)
        {
            var existingPolicy = GetPolicyById(updatedPolicy.PolicyId);
            if (existingPolicy != null)
            {
                existingPolicy.PolicyHolderName = updatedPolicy.PolicyHolderName;
                existingPolicy.PType = updatedPolicy.PType;
                existingPolicy.StartDate = updatedPolicy.StartDate;
                existingPolicy.EndDate = updatedPolicy.EndDate;
                return existingPolicy;
            }
            return null;
        }

        // Delete Policy by ID
        public void DeletePolicyById(int policyId)
        {
            var policy = GetPolicyById(policyId);
            if (policy != null)
            {
                Console.WriteLine("Are you sure you want to delete this policy? (y/n): ");
                var confirmation = Console.ReadLine()?.ToLower();
                if (confirmation == "y")
                {
                    policies.Remove(policy);
                    Console.WriteLine("Policy deleted successfully.");
                }
            }
            else
            {
                throw new PolicyNotFoundException("Policy not found.");
            }
        }

        // View Active Policies
        public List<Policy> GetActivePolicies()
        {
            return policies.FindAll(p => p.IsActive());
        }
    }
}
