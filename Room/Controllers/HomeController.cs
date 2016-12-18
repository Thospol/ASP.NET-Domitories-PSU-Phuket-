using Room.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Room.Controllers
{


    public class HomeController : Controller
    {

        private RoomContext db = new RoomContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(string username, string password)
        {

            
            var empolyee = db.Employees.Where(b => b.empid.Equals(username) && b.password.Equals(password)).FirstOrDefault();
            if (empolyee != null)
            {
                Session["UserID"] = empolyee.empid.ToString();
                Session["UserName"] = empolyee.name.ToString();
                if(Session["UserID"].ToString() != null)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    Session["error"] = "Error";
                    return View("Home", "Login");
                }


            }
            

            return View();
        }

        public ActionResult LogOut()
        {

            Session.Abandon(); // it will clear the session at the end of request
            Session.Clear();
            return RedirectToAction("index");
        }
    }
}