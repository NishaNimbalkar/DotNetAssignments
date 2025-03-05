using Menu_Driven_Application_Hackthon.Model;
using System;
using System.Collections.Generic;

namespace Menu_Driven_Application_Hackthon.Interface
{
    internal interface IPolicyRepository
    {
        bool AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy GetPolicyById(int policyId);
        Policy UpdatePolicy(Policy policy);
        void DeletePolicyById(int policyId);
        List<Policy> GetActivePolicies();
    }
}
