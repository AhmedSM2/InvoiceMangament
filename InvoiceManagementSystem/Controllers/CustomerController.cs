using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collcection.DAL;
namespace InvoiceManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDSL c_dsl = new CustomerDSL();
        // GET: Customer
        public ActionResult Index()
        {
            //var lst = c_dsl.
            return View(c_dsl.get_customers());
        }
        
        public ActionResult AddCustomer(Customer c, string Active)
        {
            
            c_dsl.addCustomer(c,Active);
            return Json(new { result = 1 });
        }
        [HttpGet]
        public ActionResult editCustomer(int id)
        {
            return View(c_dsl.getOneCustomer(id));
        }
        [HttpPost]
        public ActionResult editCustomer(Customer cust)
        {
            c_dsl.editCustomer(cust);
            return RedirectToAction("Index");
        }
        public ActionResult delteCustomer(int id)
        {
            c_dsl.del_Customer(id);
            return RedirectToAction("Index");
        }
    }
}