using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_3_24_7.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }


        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            string name = form["yourname"];
            string email = form["youremail"];
            string massege = form["yourmsg"];

            ViewBag.yourname=name;
            ViewBag.youremail =email;
            ViewBag.yourmsg= massege;
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string passowred)
        {


            if (email == "hadeelzoubi@gmail.com" && passowred == "123")
            {
                Session["UserName"] = "Hadeel";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid email or password";
                return View();
            }
        }

        public ActionResult Logout()
        {
            // Clear session
            Session["UserName"] = null;
            return RedirectToAction("Home");
        }
    }
}