using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miniProject.Models;

namespace miniProject.Controllers
{
    public class ProducttsController : Controller
    {
        private Task_CEntities db = new Task_CEntities();

        // GET: Productts
        public ActionResult Index()
        {
            return View(db.Productts.ToList());
        }

        // GET: Productts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productt productt = db.Productts.Find(id);
            if (productt == null)
            {
                return HttpNotFound();
            }
            return View(productt);
        }

        // GET: Productts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price,img")] Productt productt)
        {
            if (ModelState.IsValid)
            {
                db.Productts.Add(productt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productt);
        }

        // GET: Productts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productt productt = db.Productts.Find(id);
            if (productt == null)
            {
                return HttpNotFound();
            }
            return View(productt);
        }

        // POST: Productts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,img")] Productt productt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productt);
        }

        // GET: Productts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productt productt = db.Productts.Find(id);
            if (productt == null)
            {
                return HttpNotFound();
            }
            return View(productt);
        }

        // POST: Productts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productt productt = db.Productts.Find(id);
            db.Productts.Remove(productt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
