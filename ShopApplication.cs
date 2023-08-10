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
        //private Invoice invoice;

        public ShopApplication() 
        {
            //the data needs to be loaded from a storage medium (JSON file) before the application starts.
            LoadData();
        }
        Menu Menu = new Menu();
        UserInputs UserInputs = new UserInputs();

        int[] MenuSelectionTimeS = new int[8];//number of main menu items array and it start from 0

        public void ApplicationMainMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Application Main Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(Menu.ApplicationMainMenue);
                
                    int choice = GetMenuChoice(8);
                MenuSelectionTimeS[choice - 1]++; //the choices starts from 1 and the array index starts from 0 we substract it ind make it idded each time it will run 
                    switch (choice)
                    {
                        case 1:
                            ShopSettingsMenu();
                            break;
                        case 2:
                            ManageShopItemsMenu();
                            break;
                        case 3:
                            CreatNewInvoice(UserInputs.CustomerName(),UserInputs.CustomerPhone(),UserInputs.InvoiceNumber(),UserInputs.PaidAmount());
                            break;
                        case 4:
                            ReportStatics();
                            break;
                        case 5:
                            ReportAllInvoices();
                            break;
                        case 6:
                            SerachForInvoice(UserInputs.InvoiceNumber());
                            break;
                        case 7:
                            ProgramStatics();
                            break;
                        case 8:
                            UserInputs.ExitFunction();
                        return;

                    }
                
            }
        }

        private void ShopSettingsMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Shop Settings Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(Menu.ShopSettingMenue);

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
            Console.WriteLine("What functions you want? ");
            Console.Write("Please inter your choice =>  ");
            //int choice;
            //int userchoice = int.Parse(Console.ReadLine());
            //while( userchoice <1 || userchoice>Maximumchoice)
            int choice ;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Maximumchoice)
            {
                Console.WriteLine("You Entered invalid choice number! .");
                Console.Write("Please inter your choice again =>  ");
                

            }
            return choice;
        }
        private void ManageShopItemsMenu()
        {
            Console.WriteLine("-|-|-|-|-|-|- Manage Shop Items Menu -|-|-|-|-|-|-");
            while (true)
            {
                Menu.Show(Menu.ManageShopItemsMenue);  
                int choice = GetMenuChoice(5);
                switch (choice)
                {
                    case 1:
                        
                        AddItems(UserInputs.AddIdtemsUserInput(),UserInputs.AddNameItemsUserInput(),UserInputs.AddPriceItemsUserInput());
                        break;
                    case 2:
                        DeleteItems(UserInputs.AddIdtemsUserInput());
                        break;
                    case 3:
                        ChangeItemPrice(UserInputs.AddIdtemsUserInput(), UserInputs.AddPriceItemsUserInput());
                        break;
                    case 4:
                        ReportAllItems();
                        break;
                    case 5:
                        return;

                }
            }
            
        }

        private void AddItems(int itemID, string itemName, decimal ItemPrice)
        {
            try
            {
                

                //adding new items to the constructor
                SingleItem newitem = new SingleItem(itemID, itemName, ItemPrice);
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

        private void DeleteItems(int itemID)
        {
            try
            {
                //Console.Write("Enter the item ID that you want to be delete:    ");
                
                //int itemID = int.Parse(Console.ReadLine());
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

        private void ChangeItemPrice(int itemID,decimal newprice)
        {
            try
            {
                //Console.Write("Please enter the ID of items that you want to change its price: ");
                
                //int itemID = int.Parse(Console.ReadLine());

                var changedItem = shop.Items.Find(x => x.ItemID == itemID);
                if (changedItem != null)
                {
                    //Console.Write("Enter the new item price :");
                    
                    //decimal newprice = decimal.Parse(Console.ReadLine());
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

        private void CreatNewInvoice(string CustumerName, string CustumerPhone, string Invicenumber, decimal paidamount)
        {

            Invoice CreatingInvoice = new Invoice(Invicenumber, CustumerName, CustumerPhone, DateTime.Now, new List<InvoiceItem>());

            Console.WriteLine("Add items to the invoice press Enter after each item ID, enter 0 to finish): ");
            while (true)
            {
                int itemID =UserInputs.AddIdtemsUserInput();
                if (itemID == 0) { break; }
                //searshing for this item in items list of th shop class to find it is informations
                var itemOnShop = shop.Items.Find(x => x.ItemID == itemID);
                if (itemOnShop == null)
                {
                    Console.WriteLine("This item is not regestered");
                }
                else
                {
                    int itemQuantity = UserInputs.ItemQuantity();
                    //creating object of invoice items class and thake the information of this from shope item class using shop.find
                    InvoiceItem invoiceitems = new InvoiceItem(itemOnShop.ItemID, itemOnShop.ItemName, itemOnShop.UnitPrice, itemQuantity);
                    // now add this new information to invoice class
                    //by taking invoice item object and added to list items in the invoice class
                    //invoice.Items.Add(invoiceitems);

                    CreatingInvoice.Items.Add(invoiceitems);
                    //Console.WriteLine("Add items to the invoice and press Enter after each item ID, enter 0 to finish):");

                }
            }
            
            CreatingInvoice.PaidAmount = paidamount;
            shop.Invoices.Add(CreatingInvoice);
            SaveData();
            Console.WriteLine($"invoice with number {Invicenumber} is created successfully");
            
        }

        private void ReportStatics()
        {
            int NumberOfItems = shop.Items.Count;
            int NumberOfInvoice = shop.Invoices.Count;
            decimal TotalSales = shop.Invoices.Sum(x=>x.TotalAmount);
            //it will count first total price on invoiceitems class (UnitPrice * Quantity) for sam items
            //then will sum all total item prices in that invoice totalamount = Items.Sum(item => item.TotalPrice)
            //the it will sum all total amounts of all invoices created total sales = Invoices.Sum(x=>x.TotalAmount)
            Console.WriteLine("===>>Report sttistic Information<<===");

            Console.WriteLine($"Number of items avaliable => {NumberOfItems}");
            Console.WriteLine($"Number of Invoice Created => {NumberOfInvoice}");
            Console.WriteLine($"Total of profits fromsails => {TotalSales} OMR");

        }
        private void ReportAllInvoices()
        {
            Console.WriteLine("===>>Report Invoices Information<<===");
            Console.WriteLine("InvoiceNumber   InvoiceDate      CustomerName   NumberOfItems   TotalAmount      Balance");
            foreach (var invoice in shop.Invoices)
            {
                Console.WriteLine($"{invoice.InvoiceNumber}          {invoice.InvoiceDate}       {invoice.CustomerFullName}          {invoice.Items.Count}           {invoice.TotalAmount}           {invoice.Balance}");
            }

        }

        private void SerachForInvoice(string InvoiceNumberInput)
        {
            Console.WriteLine("===>>Serach For Invoice<<===");

            

            var InvoiceSearsh = shop.Invoices.Find(x=>x.InvoiceNumber == InvoiceNumberInput);
            if (InvoiceSearsh != null)
            {
                Console.WriteLine($"InvoiceNumber: {InvoiceSearsh.InvoiceNumber} InvoiceDate : {InvoiceSearsh.InvoiceDate}  CustomerName : {InvoiceSearsh.CustomerFullName}  NumberOfItems : {InvoiceSearsh.Items.Count}  TotalAmount: {InvoiceSearsh.TotalAmount}  Balance : {InvoiceSearsh.Balance}");
                Console.WriteLine("The Items in this Invoice are: ");
                foreach(var items in InvoiceSearsh.Items)
                {
                    Console.WriteLine($"ItemId: {items.ItemID} ItemName: {items.ItemName} UnitPrice: {items.UnitPrice} Quantity: {items.Quantity} TotalPrice: {items.TotalPrice}");
                }
            }
            else
            {
                Console.WriteLine($"The item with number {InvoiceNumberInput}");
            }
        }

        private void ProgramStatics()
        {
            Console.WriteLine("===>>Program Statics<<===");

            Console.WriteLine("Program Statistics:");
            for (int i = 0; i < MenuSelectionTimeS.Length; i++)
            {
                Console.WriteLine($"The Option {Menu.ApplicationMainMenue[i]} is selected {MenuSelectionTimeS[i]} times ");
            }
        }



    }
}
