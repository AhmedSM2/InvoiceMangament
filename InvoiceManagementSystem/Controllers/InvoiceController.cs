using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collcection.DAL;
using Collection.Entity;
using System.Web.Services;

namespace InvoiceManagementSystem.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceDSL inv_Dsl = new InvoiceDSL();
        CustomerDSL cu_Dsl = new CustomerDSL();
        CommentDSL cm_Dsl = new CommentDSL();
        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.InvoCount = inv_Dsl.CountInvo();
            Cust_Innove_Membership m = new Cust_Innove_Membership
            {
                ListInvoices = inv_Dsl.ListAllInvoices().ToList(),
                ListCustomers = cu_Dsl.get_customers().ToList(),
                ListComments = cm_Dsl.getspecificComments(0).ToList()
            };
            return View(m);
        }
        public ActionResult Index2()
        {
            // ViewBag.InvoCount = inv_Dsl.CountInvo();
            Cust_Innove_Membership m = new Cust_Innove_Membership {
                ListInvoices = inv_Dsl.ListAllInvoices().ToList(),
                ListCustomers = cu_Dsl.get_customers().ToList(),
                ListComments = cm_Dsl.getspecificComments(0).ToList()
            };
            return View(m);
        }
        public ActionResult AddInvoice(Invoice i)
        {
            if(i.Customer_Id != null && i.Collect_Date != null && i.Amount != null && i.Issue_Date != null)
            {
                inv_Dsl.AddInvoice(i);
                return Json(new { r = 1 });
            }
            else
            {
                return Json(new { });
            }
        }
        [HttpGet]
        public ActionResult delteInvoice(int id)
        {
            inv_Dsl.del_invo(id);
            return Json(new { r = 1 }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditInvoice(int id)
        {
            return View(inv_Dsl.getInvoice(id));
        }
        [HttpPost]
        public ActionResult EditInvoice(Invoice i)
        {
            inv_Dsl.editInvoice(i);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult delteCustomer(int id)
        {
            inv_Dsl.del_invo(id);
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }
        public ActionResult PayInvoice(int id, string d)
        {
            DateTime d1 = DateTime.Now.ToLocalTime();
            inv_Dsl.Pay(id, d1);
            return RedirectToAction("Index");
        }
    }
}