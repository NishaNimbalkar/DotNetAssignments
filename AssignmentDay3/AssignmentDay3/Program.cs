using Question1;

internal class Program
{
    private static void Main(string[] args)
    {
        //default Constructor can be called by using displaycarmethod

        Car c2 = new Car();
        c2.AcceptCarDetails();
        c2.DisplayCarDetails();

        Car c3 = new Car(1120, "Maruti", "Suzuki", 2015, 450000);
        c3.DisplayCarDetails();
    }
}