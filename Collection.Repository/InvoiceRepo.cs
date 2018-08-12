using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collcection.DAL;
using Collection.Entity;
namespace Collection.Repository
{
    public class InvoiceRepo
    {
        InvoiceDBEntities db = new InvoiceDBEntities();
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return db.Invoices;
        }
        public void InsertInvoice(Invoice i)
        {
            db.Invoices.Add(i);
            db.SaveChanges();
        }
        public int InvocieCounte()
        {
            var counter = db.Invoices.Count();
            return counter;
        }
        public Invoice getInov(int id)
        {
            var a = db.Invoices.SingleOrDefault(m => m.id == id);
            return a;
        }
        public void deleteInvoice(int id)
        {
            var invo = getInov(id);
            db.Invoices.Remove(invo);
            db.SaveChanges();
        }
        public void editInvo2(Invoice_comments_membership i)
        {
            CommentRepo c = new CommentRepo();
            var invo = getInov(i.invoice_obj.id);
            invo.Act_C_Date = i.invoice_obj.Act_C_Date;
            invo.Customer_Id = i.invoice_obj.Customer_Id;
            invo.invoice_no = i.invoice_obj.invoice_no;
            invo.Issue_Date = i.invoice_obj.Issue_Date;
            invo.Suspended = i.invoice_obj.Suspended;
            invo.Amount = i.invoice_obj.Amount;
            invo.Collected = i.invoice_obj.Collected;
            invo.Collect_Date = i.invoice_obj.Collect_Date;
            invo.Comments = i.invoice_obj.Comments;
            invo.Customer_Id = i.invoice_obj.Customer_Id;
            //if(i.comment_obj.comment1 != null)
            //{
            //    db.Comments.Add(i.comment_obj);
            //}
            db.SaveChanges();
        }
        public void editInvo(Invoice i)
        {
            var invo = getInov(i.id);
            invo.Act_C_Date=i.Act_C_Date;
            invo.Customer_Id=i.Customer_Id;
            invo.invoice_no=i.invoice_no;
            invo.Issue_Date=i.Issue_Date;
            invo.Suspended=i.Suspended;
            invo.Amount=i.Amount;
            invo.Collected=i.Collected;
            invo.Collect_Date=i.Collect_Date;
            invo.Comments=i.Comments;
            invo.Customer_Id=i.Customer_Id;
            db.SaveChanges();
        }
        public void Pay(int id , DateTime d)
        {
            //DateTime d = new DateTime();
            d.AddHours(2);
            var invo = getInov(id);
            invo.Collected = true;
            invo.Act_C_Date = d;
            editInvo(invo);
        }
    }
}
