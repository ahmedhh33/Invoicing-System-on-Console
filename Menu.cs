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
        public static void Show(string[] menueArray)
        {
            Console.WriteLine("-|-|-|-|-|-|- Application Main Menu -|-|-|-|-|-|-");
            for(int i = 1; i <= menueArray.Length; i++)
            {
                Console.WriteLine($"{i} ===>>{menueArray[i]}");
            }
        }
    }
}
