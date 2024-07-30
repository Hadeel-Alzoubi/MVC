﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Class_Task_CRUD.Models;

namespace Class_Task_CRUD.Controllers
{
    public class UsersController : Controller
    {
        private UserInfoEntities db = new UserInfoEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,name,email,pass,confirmPass")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,pass,confirmPass")] User user , HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                user.img = fileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        public ActionResult LogIn()
        {
            var user = db.Users.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([Bind(Include = "email,pass")] User user)
        {
            Session["LoggedUser"] = user.email;
            //var em = ;
            var database = db.Users.ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in database)
                {
                    if (item.email == user.email)
                    {
                        return RedirectToAction("Edit", new { id = item.id });
                    }
                }
                //var users = db.Users.Find(user.id);


                return RedirectToAction("Edit");
                // Authentication failed
            }
            ModelState.AddModelError("", "Invalid email or password.");

            return View(user);
        }

        public ActionResult LogOut()
        {
            Session["LoggedUser"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult ResetPass()
        {

            
            return View("ResetPassord");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPass([Bind(Include = "pass,confirmPass")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ResetPassord");
            }
            return View(user);
        }
    }
}
