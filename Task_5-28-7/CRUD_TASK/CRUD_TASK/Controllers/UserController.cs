using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_TASK.Models;

namespace CRUD_TASK.Controllers
{
    public class UserController : Controller
    {
        private User_Entities db = new User_Entities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.user_.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_ user_ = db.user_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,passwoerd,img")] user_ user_)
        {
            if (ModelState.IsValid)
            {
                db.user_.Add(user_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_ user_ = db.user_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,passwoerd,img")] user_ user_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_ user_ = db.user_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_ user_ = db.user_.Find(id);
            db.user_.Remove(user_);
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
