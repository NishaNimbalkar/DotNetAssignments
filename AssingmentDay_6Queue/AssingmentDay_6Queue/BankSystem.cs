using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingmentDay_6Queue
{
    internal class BankSystem
    {
        Queue<int> queue=new Queue<int>();

        public void AddCustomer(int cId)
        {
           queue.Enqueue(cId);
            Console.WriteLine($"Customer {cId} added to the queue.");
        }
        public void ServeCustomer()
        {
            if (queue.Count > 0)
            {
               int cId= queue.Dequeue();
                Console.WriteLine($"Serving customer {cId}.");
            }

            else
            {
                Console.WriteLine("Customer not found");
            }
        }
            
            public void checkCustomer()
        {
            if (queue.Count > 0)
            {
                 int cId= queue.Peek();
                Console.WriteLine($"Next customer in line: {cId}.");
            }
            else
            {
                Console.WriteLine("No customers in the queue.");
            }
        }



        
       
    }
}
