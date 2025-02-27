internal class Program
{
    private static void Main(string[] args)
    {
    login:
        Console.WriteLine("Enter the Password");
        string password = Console.ReadLine();

        if ((password.Length >= 6) && (password.Any(char.IsUpper)) && password.Any(char.IsDigit))
        {
            Console.WriteLine("Welcome to My Website");
        }
        else
        {
            Console.WriteLine("Password should contain atleast 6 characters , one UpperCase and one digit");
            goto login;
        }
    }
}