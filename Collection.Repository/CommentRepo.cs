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
        }
        public IEnumerable<Comment> ListComment(int id)
        {
            return db.Comments.Where(m => m.Invoices_Id == id);
        }
        public void AddComment(string comment,int id,int invo_id)
        {
            DateTime d = DateTime.Now.ToLocalTime();
            Comment c = new Comment();
            c.comment1 = comment;
            c.Date = d;
            c.User_id = id;
            c.Invoices_Id = invo_id;
            db.Comments.Add(c);
            db.SaveChanges();
        }
    }
}
