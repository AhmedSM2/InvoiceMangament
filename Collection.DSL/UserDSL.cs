using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collcection.DAL;
namespace Collection.DSL
{
    public class UserDSL
    {
        Users us = new Users();
        public User Login(User u)
        {
            return us.Login(u);
        }
        public void addUser(User U)
        {
            us.addUser(U);
        }
        public IEnumerable<User> get_users()
        {
            return us.getAllUsers();
        }
        public User getOneUser(int id)
        {
            return us.getUser(id);
        }
        public void editUser(User user)
        {
            us.editUser(user);
        }
        public void del_User(int id)
        {
            us.deleteUser(id);
        }

    }
}
