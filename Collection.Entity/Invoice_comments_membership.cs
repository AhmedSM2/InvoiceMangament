using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collcection.DAL;
namespace Collection.Entity
{
    public class Invoice_comments_membership
    {
        public Invoice invoice_obj { get; set; }
        public Comment comment_obj { get; set; }
        public IEnumerable<Comment> CommentsList { get; set; }
    }
}
