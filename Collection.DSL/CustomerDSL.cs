using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
namespace Collection.DSL
{
    public class CustomerDSL
    {
        Customers cu = new Customers();
        public void addCustomer(Customer c)
        {
            cu.addCustomer(c);
        }
        public IEnumerable<Customer> get_customers()
        {
            return cu.getAllCustomers();
        }
        public Customer getOneCustomer(int id)
        {
            return cu.getCust(id);
        }
        public void editCustomer(Customer customer)
        {
            cu.editCust(customer);
        }
        public void del_Customer(int id)
        {
            cu.deleteCustomer(id);
        }
    }
}
