using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System_on_Console
{
    //menu class with show method 
    public class Menu
    {
        public string[] ApplicationMainMenue= {"Shop Setting","Manage Shop Items","Creat New Invoice","Report: Statistics ","Report: All Invoices ","Search (1) Invoice ","Program Statistics ","Exit"};
        public string[] ShopSettingMenue = {"Load Data (Items and invoices)","Set Shop Name","Set Invoice Header (Tel / Fax / Email / Website)","Go Back"};
        public static void Show(string[] menueArray)
        {
            
            for(int i = 0; i < menueArray.Length; i++)
            {
                Console.WriteLine($"{1+i} =>{menueArray[i]}");
            }
        }
    }
}
