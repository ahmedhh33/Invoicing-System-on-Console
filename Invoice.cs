using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System_on_Console
{
    // Creating Invoice Class 
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        public decimal PaidAmount { set; get; }
        public decimal Balance => TotalAmount - PaidAmount; 

       public Invoice(string InvoiceNumber, string CustomerFullName, string PhoneNumber, DateTime InvoiceDate, List<InvoiceItem> Items)
        { 
            this.InvoiceNumber = InvoiceNumber;
            this.CustomerFullName = CustomerFullName;
            this.PhoneNumber = PhoneNumber;
            this.InvoiceDate = InvoiceDate;
            this.Items = Items;

        }
    }
}
