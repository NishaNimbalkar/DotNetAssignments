using System;

namespace Menu_Driven_Application_Hackthon.Model
{
    
    public class Policy
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

        public Policy(int policyId, string policyHolderName, PolicyType pType, DateTime startDate, DateTime endDate)
        {
            PolicyId = policyId;
            PolicyHolderName = policyHolderName;
            PType = pType;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Method to check if the policy is active
        public bool IsActive()
        {
            DateTime currentDate = DateTime.Now;
            if (StartDate <= currentDate && (EndDate >= currentDate))
                return true;
            else return false;
        }

        public override string ToString()
        {
            return $"ID: {PolicyId}, Holder: {PolicyHolderName}, Type: {PType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
        }
    }
}
