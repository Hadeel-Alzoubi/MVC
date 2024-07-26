using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_4_25_7.Models;

namespace Task_4_25_7.Controllers
{
    public class user1Controller : Controller
    {
        private usersEntities db = new usersEntities();

        // GET: user1
        public ActionResult Index()
        {
            return View(db.user1.ToList());
        }

        // GET: user1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // GET: user1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email")] user1 user1)
        {
            if (ModelState.IsValid)
            {
                db.user1.Add(user1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user1);
        }

        // GET: user1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: user1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email")] user1 user1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user1);
        }

        // GET: user1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: user1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user1 user1 = db.user1.Find(id);
            db.user1.Remove(user1);
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
