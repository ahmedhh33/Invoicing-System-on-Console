﻿using System;
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
        private void ShopSettingsMenu()
        {
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
            int userchoice = int.Parse(Console.ReadLine());
            while( userchoice <1 || userchoice>Maximumchoice)
            {
                Console.WriteLine("You Entered invalid choice number!.");
            }
            return userchoice;
        }

        private void AddingItems()
        {
            Console.WriteLine("Enter the Item ID : ");
            int itemID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Item Name : ");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter the Item Price : ");
            decimal ItemPrice = decimal.Parse(Console.ReadLine());

            //adding new items to the constructor
            var newitem = new SingleItem(itemID,itemName, ItemPrice);
            // adding this items to the list of items in the shop class
            shop.Items.Add(newitem);
            SaveData();
        }
    }
}