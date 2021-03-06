﻿using Collcection.DAL;
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
            if (c.Customer_No == 0)
            {
                c.Customer_No = db.Customers.ToList().Last().Customer_No;
                c.Customer_No = c.Customer_No + 1;
            }
            db.Customers.Add(c);
            db.SaveChanges();
        }
        public IEnumerable<Customer> getAllCustomers()
        {
            return db.Customers;
        }
        public int check_c_exsit()
        {
            var counter = db.Customers.Count();
            return counter;
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
        public Customer getLastOne()
        {
            var r = db.Customers.ToList().Last();
            return r;
        }
    }
}
