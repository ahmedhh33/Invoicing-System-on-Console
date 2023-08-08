namespace Invoicing_System_on_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-|-|-|-|-|-|- Tilal Abuied Groceries Shop -|-|-|-|-|-|-");
            ShopApplication shopApplication = new ShopApplication();
            shopApplication.ApplicationMainMenu();
        }
    }

}