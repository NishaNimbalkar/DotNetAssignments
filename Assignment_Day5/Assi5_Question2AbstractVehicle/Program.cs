using Assi5_Question2AbstractVehicle;

internal class Program
{
    private static void Main(string[] args)
    {
        Vehicle vehicle = new Twowheeler(11,"hero-Honda",120000);
        vehicle.GetInsuranceAmount();

        Vehicle vehicle1 = new FourWheeler(1120, "Audi", 3000000);
        vehicle1.GetInsuranceAmount();
        Vehicle vehicle2 = new Commercial(1122, "Tractor", 546724);
        vehicle2.GetInsuranceAmount();
    }
}