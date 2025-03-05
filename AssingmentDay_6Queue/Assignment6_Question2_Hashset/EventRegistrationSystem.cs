using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6_Question2_Hashset
{
    internal class EventRegistrationSystem
    {
        private Dictionary<string, HashSet<int>> registration = new Dictionary<string, HashSet<int>>();

        // Method to register a student for a workshop
        public void RegisterStudent(string workshopname, int stu_id)
        {

            if (!registration.ContainsKey(workshopname))     //registration.ContainsKey("photography")
            {
                registration[workshopname] = new HashSet<int>();   //"photography"=new 101;   
            }
            if (registration[workshopname].Add(stu_id))
            {
                Console.WriteLine($"Student {stu_id} added successfully for the workshop {workshopname}");
            }
            else
            {
                Console.WriteLine($"Student {stu_id} already exists for the workshop {workshopname}");
            }
        }
        public void ShowRegisteredStudent(string workshopname)
        {
            if (registration.ContainsKey(workshopname))
            {
                Console.WriteLine($"Student registered for {workshopname} is");
                foreach (int studentId in registration[workshopname])
                {
                    Console.WriteLine($"{studentId}");
                }
            }
        }
   
    }

}

       
           

