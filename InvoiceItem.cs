using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System_on_Console
{
    // creating Items class
    public class InvoiceItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public InvoiceItem(int ItemID, string ItemName, decimal UnitPrice, int Quantity) 
        {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
        }
    }
}
