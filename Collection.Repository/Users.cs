using Collcection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Repository
{
    public class Users
    {
        InvoiceDBEntities db = new InvoiceDBEntities();
        public void addCustomer(User u)
        {
            var u_no = db.Customers.ToList().Last();
            u.Customer_No = (u_no. + 1);
            db.Users.Add(u);
            db.SaveChanges();
        }
        public IEnumerable<User> getAllCustomers()
        {
            return db.Users;
        }
        public User getCust(int id)
        {
            var us = db.Users.SingleOrDefault(m => m.id == id);
            return us;
        }
        public void editCust(User u)
        {
            var us = getCust(u.id);
            us.Name = u.Name;
            us.Active = u.Active;
            us.Customer_No = u.Customer_No;
            db.SaveChanges();
        }
        public void deleteCustomer(int id)
        {
            var cust = getCust(id);
            db.Users.Remove(cust);
            db.SaveChanges();
        }
    }
}
