using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDrivenApplication_Hackathon2.Model
{
    internal class Policy
    {

        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }

        public enum PolicyType
        {
            Life,
            Health,
            Vehicle,
            Property
        }

        public PolicyType PType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy()
        {

        }

        public Policy(int policyId, string policyHolderName, PolicyType pType, DateTime startDate, DateTime endDate)
        {
            PolicyId = policyId;
            PolicyHolderName = policyHolderName;
            PType = pType;
            StartDate = startDate;
            EndDate = endDate;
        }
        public override string ToString()
        {
            return $"ID: {PolicyId}, Holder: {PolicyHolderName}, Type: {PType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
        }
    }
}
