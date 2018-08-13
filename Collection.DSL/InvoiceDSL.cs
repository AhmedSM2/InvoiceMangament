using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
using Collection.Entity;
namespace Collection.DSL
{
    public class InvoiceDSL
    {
        InvoiceRepo invo = new InvoiceRepo();
        public IEnumerable<Invoice> ListAllInvoices()
        {
           return invo.GetAllInvoices();
        }
        public void AddInvoice(Invoice i)
        {
            invo.InsertInvoice(i);
        }
        public int CountInvo()
        {
            return invo.InvocieCounte();
        }
        public void del_invo(int id)
        {
            invo.deleteInvoice(id);
        }
        public void editInvoice(Invoice i)
        {
            invo.editInvo(i);
        }
        public void editInvoice2(Invoice_comments_membership i)
        {
            invo.editInvo2(i);
        }
        public Invoice getInvoice(int i)
        {
            return invo.getInov(i);
        }
        public Invoice_comments_membership getInvoice_comments(int i)
        {
            CommentRepo c_repo = new CommentRepo();
            Invoice_comments_membership im = new Invoice_comments_membership
            {
                invoice_obj = invo.getInov(i),
              //  CommentsList =  c_repo.ListComment(i)
            };
            return im;
        }
        public void Pay(int id,DateTime d)
        {
            invo.Pay(id,d);
        }
    }
}
