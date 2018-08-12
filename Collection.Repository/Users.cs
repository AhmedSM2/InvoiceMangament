using Collcection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Repository
{
    public class Users
    {
        InvoiceDBEntities db = new InvoiceDBEntities();
        public User Login(User u)
        {
            return db.Users.SingleOrDefault(m => m.user_name == u.user_name && m.password == u.password);
        }
        public void addUser(User u)
        {
            var u_no = db.Users.ToList().Last();

            if (u_no.user_no != null)
                u.user_no = (u_no.user_no + 1);
            else
                u.user_no = 50;

            db.Users.Add(u);
            db.SaveChanges();
        }
        public IEnumerable<User> getAllUsers()
        {
            return db.Users;
        }
        public User getUser(int id)
        {
            var us = db.Users.SingleOrDefault(m => m.id == id);
            return us;
        }
        public void editUser(User u)
        {
            var us = getUser(u.id);

            us.Name = u.Name;
            us.Active = u.Active;
            us.user_name = u.user_name;
            
            db.SaveChanges();
        }
        public void deleteUser(int id)
        {
            var Us = getUser(id);

            db.Users.Remove(Us);
            db.SaveChanges();
        }
    }
}
