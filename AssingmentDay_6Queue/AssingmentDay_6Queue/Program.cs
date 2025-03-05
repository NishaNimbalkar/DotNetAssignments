using AssingmentDay_6Queue;

internal class Program
{
    private static void Main(string[] args)
    {
        BankSystem bs = new BankSystem();
        bs.AddCustomer(11);
        bs.AddCustomer(12);
        bs.AddCustomer(13);
        bs.AddCustomer(14);
        bs.ServeCustomer();
        bs.checkCustomer();
        bs.ServeCustomer();
        bs.checkCustomer();

    }
}