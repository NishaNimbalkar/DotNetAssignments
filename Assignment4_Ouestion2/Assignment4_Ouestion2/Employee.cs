using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Ouestion2
{
   internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public virtual void Displaydetails()
        {
            Console.WriteLine($"Name is {Name} and salary is {Salary} ");
        }
    }
}
