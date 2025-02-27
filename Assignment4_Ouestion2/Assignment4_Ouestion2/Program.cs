using Assignment4_Ouestion2.A4t2;
using Assignment4_Ouestion2;

internal class Program
{
    static void Main(string[] args)
    {
        
        //Employee e1 = new Employee();
        //e1.name = "nisha";
        //e1.salary = 10000;
        //e1.displaydetails();

        //Manager m1 = new Manager();
        //m1.name = "nisha";
        //m1.salary = 80000;
        //m1.Bonus = 5000;
        //m1.displaydetails();



        Employee m2 = new Manager { name = "neha", Bonus = 2300, salary = 50600 };
        m2.displaydetails();
    }
}