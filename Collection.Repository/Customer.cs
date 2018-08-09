using Collcection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Collection.Repository
{
    public class Customers
    {
        InvoiceDBEntities db = new InvoiceDBEntities();
        public void addCustomer(Customer c)
        {
            var c_no = db.Customers.ToList().Last();
            c.Customer_No = (c_no.Customer_No + 1);
            db.Customers.Add(c);
            db.SaveChanges();
        }
        public IEnumerable<Customer> getAllCustomers()
        {
            return db.Customers;
        }
        public Customer getCust(int id)
        {
            var cust = db.Customers.SingleOrDefault(m => m.id == id);
            return cust;
        }
        public void editCust(Customer cu)
        {
            var cust = getCust(cu.id);
            cust.Name = cu.Name;
            cust.Active = cu.Active;
            cust.Customer_No = cu.Customer_No;
            db.SaveChanges();
        }
        public void deleteCustomer(int id)
        {
            var cust = getCust(id);
            db.Customers.Remove(cust);
            db.SaveChanges();
        }
    }
}
