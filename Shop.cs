using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System_on_Console
{
    // creating Shop class 
    public class Shop
    {
        public string ShopName { get; set; }
        public string InvoiceHeader { get; set; }
        public List<SingleItem> Items { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
}
