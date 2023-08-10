using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System_on_Console
{
    public class UserInputs
    {
        public int AddIdtemsUserInput()
        {
            try
            {
                Console.Write("Enter the Item ID : ");
                int itemID = int.Parse(Console.ReadLine());
                return itemID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be integer " + ex.Message);
            }
            return AddIdtemsUserInput();
        }
        public string AddNameItemsUserInput()
        {
            try
            {

                Console.Write("Enter the Item Name : ");

                string itemName = Console.ReadLine();
                return itemName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be string " + ex.Message);
            }
            return AddNameItemsUserInput();

        }
        public decimal AddPriceItemsUserInput()
        {
            try
            {
                Console.Write("Enter the Item Price : ");

                decimal ItemPrice = decimal.Parse(Console.ReadLine());
                return ItemPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be decimal " + ex.Message);
            }
            return AddPriceItemsUserInput();
        }
        public string CustomerName()
        {
            try
            {
                Console.Write("Please enter custumer full name :    ");
                string CustumerName = Console.ReadLine();
                return CustumerName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be string " + ex.Message);
            }
            return CustomerName();

        }
        public string CustomerPhone()
        {
            try
            {
                Console.Write("Please enter custumer Phone number : ");
                string CustumerPhone = Console.ReadLine();
                return CustumerPhone;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be string " + ex.Message);
            }
            return CustomerPhone();
        }
        public string InvoiceNumber()
        {
            try
            {
                Console.Write("Enter the InvoiceNumber: ");
                string Invicenumber = Console.ReadLine();
                return Invicenumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be string " + ex.Message);
            }
            return InvoiceNumber();
        }
        public int ItemQuantity()
        {
            try
            {
                Console.Write("Enter the Quantity of this item : ");
                int itemQuantity = int.Parse(Console.ReadLine());
                return itemQuantity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be integer " + ex.Message);
            }
            return ItemQuantity();
        }
        public decimal PaidAmount()
        {
            try
            {
                Console.Write("Enter the Paid amount : ");
                decimal paidamount = decimal.Parse(Console.ReadLine());
                return paidamount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be decimal " + ex.Message);
            }
            return PaidAmount();
        }

        public void ExitFunction()
        {
            try
            {
                Console.Write("Are you sure you want to exit? (Y/N)   ");
                string response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    Environment.Exit(0);
                }
                else if (response == "N")
                {
                    ShopApplication shopApplication = new ShopApplication();
                    shopApplication.ApplicationMainMenu();
                }
                else
                {
                    Console.WriteLine("You intered invalid choice");
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions the input must be char " + ex.Message);
                 
            }
            ExitFunction();

        }
    }
}
