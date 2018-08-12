using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
namespace Collection.DSL
{
    public class CommentDSL
    {
        CommentRepo cm_repo = new CommentRepo();
        public IEnumerable<Comment> getspecificComments(int id)
        {
            return cm_repo.SpecificComments(id);
        }
        public IEnumerable<Comment> getListComments(int id)
        {
            return cm_repo.ListComment(id);
        }
        public void AddComment(string comment, int id, int invo_id)
        {
            cm_repo.AddComment(comment, id, invo_id);
        }
    }
}
