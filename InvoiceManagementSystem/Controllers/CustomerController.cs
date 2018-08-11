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
            ViewBag.count = c_dsl.count_customer();
            //var lst = c_dsl.
            return View(c_dsl.get_customers());
        }
        
        public ActionResult AddCustomer( int Customer_No,Customer c,string Active)
        {
            c_dsl.addCustomer(c, Customer_No,Active);
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
        [HttpGet]
        public ActionResult delteCustomer(int id)
        {
            c_dsl.del_Customer(id);
            return Json( new { result = 1 },JsonRequestBehavior.AllowGet) ;
            //return RedirectToAction("Index");
        }
    }
}