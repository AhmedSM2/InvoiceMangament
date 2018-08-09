using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
namespace Collection.DSL
{
    public class UserDSL
    {
        Users us = new Users();
        //public void addCustomer(Customer c)
        //{
        //    us.addCustomer(c);
        //}
        //public IEnumerable<Customer> get_customers()
        //{
        //    //return us.getAllCustomers();
        //}
        //public Customer getOneCustomer(int id)
        //{
        //    return us.getCust(id);
        //}
        //public void editCustomer(Customer customer)
        //{
        //    us.editCust(customer);
        //}
        public void del_Customer(int id)
        {
            us.deleteCustomer(id);
        }

    }
}
