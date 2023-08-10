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
            Console.Write("Enter the Item ID : ");

            int itemID = int.Parse(Console.ReadLine());
            return itemID;
            //Console.Write("Enter the Item Name : ");

            //string itemName = Console.ReadLine();
            //Console.Write("Enter the Item Price : ");

            //decimal ItemPrice = decimal.Parse(Console.ReadLine());
        }
        public string AddNametemsUserInput()
        {
            Console.Write("Enter the Item Name : ");

            string itemName = Console.ReadLine();
            return itemName;
            
            //Console.Write("Enter the Item Price : ");

            //decimal ItemPrice = decimal.Parse(Console.ReadLine());
        }
        public decimal AddPricetemsUserInput()
        {
            
            

            Console.Write("Enter the Item Price : ");

            decimal ItemPrice = decimal.Parse(Console.ReadLine());
            return ItemPrice;
        }
    }
}
