using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name , string image , string price)
        {
            // the ?? to add defualt value if the input is null 
            var product = Session["Products"] as List<Dictionary<string,string>> ?? new List<Dictionary<string, string>>();

            var pro = new Dictionary<string, string>()
            {
                {"name" ,name },
                {"image" ,image },
                {"price" , price }
            };

            product.Add(pro);
            Session["Products"] = product;
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            var product = Session["Products"] as List<Dictionary<string, string>> ?? new List<Dictionary<string, string>>();
            return View(product);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}