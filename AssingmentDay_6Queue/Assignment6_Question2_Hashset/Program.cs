using Assignment6_Question2_Hashset;

internal class Program
{
    private static void Main(string[] args)
    {
        EventRegistrationSystem er=new EventRegistrationSystem();
        er.RegisterStudent("photography workshop",101);
        er.RegisterStudent("IT workshop",102);
        er.RegisterStudent("photography Workshop", 103);
        er.RegisterStudent("AI workshop", 101);
        er.RegisterStudent("DS workshop", 101);
        er.RegisterStudent("AI workshop", 104);


        er.ShowRegisteredStudent("workshop5");

            
    }
}