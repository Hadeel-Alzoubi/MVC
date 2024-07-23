using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_23_7.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            var name = form["Name"];
            var phoneNumber = form["PhoneNumber"];
            var gender = form["Gender"];
            var degree = form["Degree"];
            var interests = form.GetValues("Interests");

            TempData["Name"] = name;
            TempData["PhoneNumber"] = phoneNumber;
            TempData["Gender"] = gender;
            TempData["Degree"] = degree;
            TempData["Interests"] = interests;

            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.PhoneNumber = TempData["PhoneNumber"];
            ViewBag.Gender = TempData["Gender"];
            ViewBag.Degree = TempData["Degree"];
            ViewBag.Interests = TempData["Interests"];

            return View();
        }

    }
}