using Collcection.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Repository
{
    public class CommentRepo
    {
        InvoiceDBEntities db = new InvoiceDBEntities();
        public IEnumerable<Comment> SpecificComments(int id)
        {
            return db.Comments;
            //return db.Comments.Where(m=> m.Invoices_Id == id);
        }
    }
}
