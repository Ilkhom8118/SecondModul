namespace Inkapsulatsiya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.MyProperty = 10;
            Console.WriteLine(account.MyProperty);
        }
    }
}
