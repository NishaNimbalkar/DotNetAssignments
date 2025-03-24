using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDrivenApplication_Hackathon2.Exception1;
using MenuDrivenApplication_Hackathon2.Model;
using MenuDrivenApplication_Hackathon2.Utility;



namespace MenuDrivenApplication_Hackathon2.Repository
{
    internal class PolicyRepository : IPolicyRepository
    {
        //SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        string connstring;
        public PolicyRepository()
        {
            cmd = new SqlCommand();
            connstring = DbConn.GetConnectionString();
        }

        public int AddPolicy(Policy policies)
        {
            try
            {
                Policy searchResut = GetPolicyById(policies.PolicyId);

                if (searchResut == null)
                {

                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        cmd.CommandText = "Insert into Policy values(@PolicyHolderName,@PolicyType,@StartDate,@EndDate)";
                        //cmd.Parameters.AddWithValue("@PolicyId", policies.PolicyId);
                        cmd.Parameters.AddWithValue("@PolicyHolderName", policies.PolicyHolderName);
                        cmd.Parameters.AddWithValue("@PolicyType", policies.PType);
                        cmd.Parameters.AddWithValue("@StartDate", policies.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", policies.EndDate);
                        cmd.Connection = conn;
                        conn.Open();
                         cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new PolicyAlreadyExistExeception($"{policies.PolicyId} already Exists");

                }
            }
            catch (PolicyAlreadyExistExeception poe)
            {
                Console.WriteLine(poe.Message);
                
            }
            return 0;

        }


        public List<Policy> GetAllPolicies()
        {

            List<Policy> policies = new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Select * from Policy";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyId = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.PType = (Policy.PolicyType)reader.GetInt32("PolicyType");
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policies.Add(policy);
                }
                return policies;
            }
        }

        public Policy GetPolicyById(int policyId)
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                cmd.CommandText = "SELECT * FROM Policy WHERE PolicyId = @PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        Policy policy = new Policy
                        {
                            PolicyId = reader.GetInt32("PolicyId"),
                            PolicyHolderName = reader.GetString("PolicyHolderName"),
                            PType = (Policy.PolicyType)reader.GetInt32("PolicyType"),
                            StartDate = reader.GetDateTime("StartDate"),
                            EndDate = reader.GetDateTime("EndDate")
                        };
                        return policy;
                    }
                    else
                    {
                        throw new PolicyNotFoundException("No policy found"); // 
                    }

                }
                catch (PolicyNotFoundException poe)
                {
                    Console.WriteLine(poe.Message);

                   

                }
                return null;


            }
        }
        public int UpdatePolicy(Policy policy)
        {
            using (SqlConnection sqlconn = new SqlConnection(connstring))
            {
                
                cmd.CommandText = "UPDATE Policy SET PolicyHolderName = @PolicyHolderName, PolicyType = @PolicyType, StartDate = @StartDate, EndDate = @EndDate WHERE PolicyId = @PolicyId";

               
                cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);
                 cmd.Parameters.AddWithValue("@PolicyType", policy.PType);  // Assuming PolicyType is an enum
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);

                cmd.Connection = sqlconn;
                sqlconn.Open();

                return cmd.ExecuteNonQuery();
            }


        }
        public int DeletePolicy(int id)
        {
            int result=0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    cmd.CommandText = "Delete from Policy where PolicyId=@PolicyId";
                    //Console.WriteLine("Enter the id Do you want to delette");
                    cmd.Parameters.AddWithValue("@PolicyId", id);
                    cmd.Connection = conn;
                    conn.Open();
                    result= cmd.ExecuteNonQuery();
                    if (result==0)
                    {
                        throw new PolicyNotFoundException("Policy not Found");
                    }
                    else
                    {
                        Console.WriteLine("Policy delected Successfully");
                    }
                }
            }
            catch (PolicyNotFoundException pof)
            {
                Console.WriteLine(pof.Message);
            }
            return result;
        }

    }
}


