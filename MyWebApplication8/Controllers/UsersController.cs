using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication8.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        dxcdbEntities db = new dxcdbEntities();
        public ActionResult Home()
        {
            ViewBag.Countries = new List<string> { "India", "Japan", "Pakistan", "Neterlands" };
            ViewData["Countries1"]= new List<string> { "India", "Japan", "Pakistan", "Neterlands" };
            var res = db.Users.ToList();
            return View(res);
        }
        [HttpGet]
        public ActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewUser(User u1)
        {
            db.Users.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            User u1 = db.Users.Find(id);
            return View(u1);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id,FormCollection frm)
        {
            User u1 = db.Users.Find(id);
            if (u1 != null)
            {
                db.Users.Remove(u1);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            else
                return View();
        }

        public ActionResult UserDetails(int id)
        {
            User u = db.Users.Find(id);
            return View(u);
        }

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            User u1 = db.Users.Find(id);
            return View(u1);
        }

        [HttpPost]
        public ActionResult UpdateUser(int id, FormCollection frm)
        {
            User u1 = db.Users.Find(id);
            if (u1 != null)
            {
                u1.username = frm[2].ToString();
                u1.password = frm[3].ToString();
                u1.email = frm[4].ToString();
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            else
                return View();
        }

        public ActionResult Print()
        {
            return Redirect("/WebForm1.aspx");
        }
    }
}