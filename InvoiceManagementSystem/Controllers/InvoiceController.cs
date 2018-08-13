using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collcection.DAL;
using Collection.Entity;
using System.Web.Services;
using Newtonsoft.Json;

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
            ViewBag.InvoCount = inv_Dsl.CountInvo();
            Cust_Innove_Membership m = new Cust_Innove_Membership
            {
                ListInvoices = inv_Dsl.ListAllInvoices().ToList(),
                ListCustomers = cu_Dsl.get_customers().ToList(),
                ListComments = cm_Dsl.getspecificComments(0).ToList()
            };
            return View(m);
        }
        public ActionResult AddInvoice(Invoice i)
        {
            if(i.Customer_Id != null && i.Collect_Date != null && i.Amount != 0 && i.Issue_Date != null)
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
            var a = inv_Dsl.getInvoice_comments(id);
            return View(inv_Dsl.getInvoice_comments(id));
        }
        [HttpPost]
        public ActionResult EditInvoice(Invoice_comments_membership i)
        {
            inv_Dsl.editInvoice2(i);
            return RedirectToAction("Index2");
        }

        [HttpGet]
        public ActionResult EditInvoice2(int id)
        {
            return View(inv_Dsl.getInvoice_comments(id));
        }
        [HttpPost]
        public ActionResult EditInvoice2(Invoice i)
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
            return RedirectToAction("Index2");
        }
        // Add comment 
        public ActionResult AddComment(string comment, int id, int invo_id)
        {
            cm_Dsl.AddComment(comment, id, invo_id);
            return RedirectToAction("Index2");
        }
        // search
        public string SearchResult(string IssueFrom, string IssueTo, string ColFrom, string ColTo, string Customer)
        {
            Cust_Innove_Membership m = new Cust_Innove_Membership
            {
                ListInvoices = inv_Dsl.ListAllInvoices().ToList(),
                ListCustomers = cu_Dsl.get_customers().ToList(),
                ListComments = cm_Dsl.getspecificComments(0).ToList()
            };

            DateTime A = new DateTime(2018, 1, 1);
            var invoices2 = new List<Invoice> ();
            DateTime IT = CreateDateTime(IssueTo);
            DateTime IF = CreateDateTime(IssueFrom);
            //DateTime Col1 = CreateDateTime(ColTo);
            //DateTime col2 = CreateDateTime(ColFrom);

            if (Customer == "0")
            {
                foreach (var item in m.ListInvoices)
                {

                    if (item.Issue_Date >= IF && item.Issue_Date <= IT)
                    {
                        invoices2.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in m.ListInvoices)
                {
                    if (item.Issue_Date >= IF && item.Issue_Date <= IT && Customer == item.Customer.Name /*&& item.Collect_Date >= Col1 && item.Collect_Date <= col2*/)
                    {
                        invoices2.Add(item);
                    }
                }
            }
            var a =JsonConvert.SerializeObject(invoices2,
                Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });


            return a;
        }
        public DateTime CreateDateTime(string a)
        {
            int year = Convert.ToInt32((a.Split('-'))[0]);
            int month = Convert.ToInt32((a.Split('-'))[1]);
            int day = Convert.ToInt32((a.Split('-'))[2]);

            DateTime A = new DateTime(year, month, day);
            return A;

        }
    }
}