using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collcection.DAL;
namespace Collection.Entity
{
    public class Cust_Innove_Membership
    {
        public IEnumerable<Customer> ListCustomers { get; set; }
        public IEnumerable<Invoice> ListInvoices { get; set; }
        public IEnumerable<Comment> ListComments { get; set; }
        public Invoice Invo_obj { get; set; }
    }
}
