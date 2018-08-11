using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
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
        public Invoice getInvoice(int i)
        {
            return invo.getInov(i);
        }
        public void Pay(int id,DateTime d)
        {
            invo.Pay(id,d);
        }
    }
}
