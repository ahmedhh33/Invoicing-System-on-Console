using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Invoicing_System_on_Console
{
    //Implementing the main application class
    public class ShopApplication
    {
        private const string DATA_FILE = "shopdata.json";
        private Shop shop;

        public ShopApplication() 
        {
            //the data needs to be loaded from a storage medium (JSON file) before the application starts.
            LoadData();
        }

        public void ApplicationMainMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Application Main Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(new string[] 
                {
                    "Shop Setting",
                    "Manage Shop Items",
                    "Creat New Invoice",
                    "Report: Statistics ",
                    "Report: All Invoices ",
                    "Search (1) Invoice ",
                    "Program Statistics ",
                    "Exit"
                });
                
                    int choice = GetMenuChoice(8);
                    switch (choice)
                    {
                        case 1:
                            ShopSettingsMenu();
                            break;
                        case 2:
                            ManageShopItemsMenu();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                        Console.WriteLine("Are you sure you want to exit? (Y/N)");
                        string response = Console.ReadLine().ToUpper();
                        if (response == "Y")
                        {
                            Environment.Exit(0);
                        }
                        else if (response == "N")
                        {
                            ApplicationMainMenu();
                        }
                        else
                        {
                            Console.WriteLine("You intered invalid choice");
                        }
                        return;

                    }
                
            }
        }

        private void ShopSettingsMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Shop Settings Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(new string[]
                {
                "Load Data (Items and invoices)",
                "Set Shop Name",
                "Set Invoice Header (Tel / Fax / Email / Website)",
                "Go Back"
                });

                int choice = GetMenuChoice(4);
                switch (choice)
                {
                    case 1:
                        LoadData();
                        break;
                    case 2:
                        SetShopName();
                        break;
                    case 3:
                        SetInvoiceHeader();
                        break;
                    case 4:
                        return;
                    //default:
                    //    Console.WriteLine("Invalid choice. Please try again.");
                    //    break;
                }
            }
        }

        private void LoadData()
        {
            if (File.Exists(DATA_FILE))
            {
                string jsonData = File.ReadAllText(DATA_FILE);
                shop = JsonConvert.DeserializeObject<Shop>(jsonData);
                //it will return the deserialaysed object from JSON string

            }
            else
            {
                //If the file does not exist, it initializes a new shop object with default values.
                //so the shop object is prepared for use in the application in eather ways
                shop = new Shop
                {
                    ShopName="Tilal Abueid Grocery Shop",
                    InvoiceHeader = "Tele: 22343238 / Email: Tilal_Abueid@gmail.com | Website: www.TilalAbueidGrocery.com",
                    Items = new List<SingleItem>(),
                    Invoices = new List<Invoice>()
                };

            }
            Console.WriteLine("Data loaded successfully.");
        }
        private void SaveData()
        {
            try
            {
                //here it convert the object to string to save it in json datafile serialaizing
                string jsonData = JsonConvert.SerializeObject(shop, Formatting.Indented);
                File.WriteAllText(DATA_FILE, jsonData);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while saving data: " + ex.Message);
            }
        }
        private void SetShopName()
        {
            Console.WriteLine("Please Enter the New Name of the Shop : ");
            shop.ShopName = Console.ReadLine();
            SaveData();//it save the new data changed
        }
        private void SetInvoiceHeader()
        {
            Console.WriteLine("Set the Invoice header (Tele/Fax/Email/Website): ");
            shop.InvoiceHeader = Console.ReadLine();
            SaveData();
        }

        private int GetMenuChoice(int Maximumchoice)
        {
            // this function check for the menu list and ask user to enter the choice
            Console.WriteLine("What functions you want?");
            Console.WriteLine("Please inter your choice");
            //int choice;
            //int userchoice = int.Parse(Console.ReadLine());
            //while( userchoice <1 || userchoice>Maximumchoice)
            int choice ;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Maximumchoice)
            {
                Console.WriteLine("You Entered invalid choice number! .");
                Console.WriteLine("Please inter your choice again .");

            }
            return choice;
        }
        private void ManageShopItemsMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Manage Shop Items Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(new string[] 
                {
                    "Add Items",
                    "Delete Items",
                    "Change Item Price",
                    "Report All Items",
                    "Go Back"
                });
                int choice = GetMenuChoice(5);
                switch (choice)
                {
                    case 1:
                        AddItems();
                        break;
                    case 2:
                        DeleteItems();
                        break;
                    case 3:
                        ChangeItemPrice();
                        break;
                    case 4:
                        ReportAllItems();
                        break;
                    case 5:
                        return;

                }
            }
            
        }

        private void AddItems()
        {
            try
            {
                Console.WriteLine("Enter the Item ID : ");
                int itemID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Item Name : ");
                string itemName = Console.ReadLine();
                Console.WriteLine("Enter the Item Price : ");
                decimal ItemPrice = decimal.Parse(Console.ReadLine());

                //adding new items to the constructor
                var newitem = new SingleItem(itemID, itemName, ItemPrice);
                // adding this items to the list of items in the shop class
                shop.Items.Add(newitem);
                SaveData();
                Console.WriteLine("The item added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exceptions"+ex.Message);
            }
        }

        private void DeleteItems()
        {
            try
            {
                Console.WriteLine("Enter the item ID that you want to be delete:");
                int itemID = int.Parse(Console.ReadLine());
                // search for the item in the items list in shop class
                var RemovingItem = shop.Items.Find(x => x.ItemID == itemID);
                if (RemovingItem != null)
                {
                    //if the items that need to deleted found then delet it
                    shop.Items.Remove(RemovingItem);
                    SaveData();
                    Console.WriteLine("The item removed successfully");
                }
                else
                {
                    Console.WriteLine("The items not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input exception"+ex.Message);
            }
        }

        private void ChangeItemPrice()
        {
            try
            {
                Console.WriteLine("Please enter the ID of items that you want to change its price: ");
                int itemID = int.Parse(Console.ReadLine());

                var changedItem = shop.Items.Find(x => x.ItemID == itemID);
                if (changedItem != null)
                {
                    Console.WriteLine("Enter the new item price :");
                    decimal newprice = decimal.Parse(Console.ReadLine());
                    changedItem.UnitPrice = newprice;
                    SaveData();
                    Console.WriteLine("item price updated succesfuly");
                }
                else
                {
                    Console.WriteLine("the item not found!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error happened due to wrong input "+ex.Message);
            }
        }

        private void ReportAllItems()
        {
            Console.WriteLine("-|-|-|-|- All shop items -|-|-|-|-  ");
            foreach (var item in shop.Items)
            {
                Console.WriteLine($"Item ID : {item.ItemID} Item Name : {item.ItemName} Item price : {item.UnitPrice}");
            }
        }

        private void CreatNewInvoice()
        {
            Console.WriteLine("Please enter custumer full name :");
            string CustumerName = Console.ReadLine();
            Console.WriteLine("Please enter custumer Phone number :");
            string CustumerPhone = Console.ReadLine();
            Console.WriteLine("Enter the InvoiceNumber");
            string Invicenumber = Console.ReadLine();

            var CreatingInvoice = new Invoice(Invicenumber, CustumerName, CustumerPhone, DateTime.Now, new List<InvoiceItem>());

            Console.WriteLine("Add items to the invoice press Enter after each item ID, enter 0 to finish):");
            while (true)
            {
                //entering the item id
                int itemID = int.Parse(Console.ReadLine());

                if(itemID == 0) { break; }
                //searshing for this item in items list of th shop class to find it is informations
                var itemOnShop = shop.Items.Find(x => x.ItemID == itemID);
                if(itemOnShop == null) 
                {
                    Console.WriteLine("This item is not regestered"); 
                }
                else 
                {
                    Console.WriteLine("Enter the Quantity of this item : ");
                    int itemQuantity = int.Parse(Console.ReadLine());
                    //creating object of invoice items class and thake the information of this from shope item class using shop.find
                    var invoiceitems = new InvoiceItem(itemOnShop.ItemID, itemOnShop.ItemName, itemOnShop.UnitPrice, itemQuantity);
                    // now add this new information to invoice class
                    //by taking invoice item object and added to list items in the invoice class
                    CreatingInvoice.Items.Add(invoiceitems);

                    Console.WriteLine("Enter the Paid amount : ");
                    decimal paidamount = decimal.Parse(Console.ReadLine());

                    SaveData();

                    Console.WriteLine($"invoice with number {Invicenumber} is created successfully");
                     
                }
            }



        }

    }
}
