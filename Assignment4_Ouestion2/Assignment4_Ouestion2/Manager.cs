using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Ouestion2
{

    
        class Manager : Employee
        {
            public int Bonus { get; set; }


            public override void Displaydetails()
            {
                Console.WriteLine($"Name : {Name}  salary : {Salary}  bonus : {Bonus}");
            }

        
        }
    }
