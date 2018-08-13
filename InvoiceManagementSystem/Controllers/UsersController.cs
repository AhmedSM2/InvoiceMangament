using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collcection.DAL;
namespace InvoiceManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        UserDSL u_dsl = new UserDSL();
        // GET: User
        public ActionResult Index()
        {
            return View(u_dsl.get_users());
        }
        
        [HttpGet]
        public ActionResult Add_User()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_User(User U,string c)
        {
            if(c == "on"){U.Active = true;}
            else { U.Active = false; }
            U.Type =2 ;
            u_dsl.addUser(U);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult editUser(int id)
        {
            return View(u_dsl.getOneUser(id));
        }
        [HttpPost]
        public ActionResult editUser(User user)
        {
            u_dsl.editUser(user);
            return RedirectToAction("Index");
        }

        public ActionResult delteUser(int id)
        {
           u_dsl.del_User(id);
            return RedirectToAction("Index");
        }
    }
}