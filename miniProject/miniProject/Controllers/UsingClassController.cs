using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace miniProject.Controllers
{
    public class UsingClassController : Controller
    {
        ProductProject db = new ProductProject();
        // GET: UsingClass
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, int price , string img)
        {
            if (ModelState.IsValid)
            {
                db.name = name;
                db.price = price;
                db.img = img;
                return RedirectToAction("card");
            }

            return View();
        }

        public ActionResult card()
        {
            return View();
        }


        //public ActionResult card()
        //{
        //   var name = ViewBag.name;
        //   var price = ViewBag.price;
        //   var img = ViewBag.img;

        //    return View("card");
        //}


    }
}