using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDrivenApplication_Hackathon2.Model;


namespace MenuDrivenApplication_Hackathon2.Repository
{
    internal interface IPolicyRepository
    {
        public int AddPolicy(Policy policies);
        public List<Policy> GetAllPolicies();
        public Policy GetPolicyById(int policyId);
        public int UpdatePolicy(Policy policy);
        public int DeletePolicy(int id);


    }
}
