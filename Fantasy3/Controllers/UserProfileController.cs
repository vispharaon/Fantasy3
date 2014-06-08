using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantasy3.Models;

namespace Fantasy3.Controllers
{
    public class UserProfileController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var user = db.user.Include(u => u.usergroup);
            var users = db.user.Where(u => u.UserGroup_idUserGroup == 1);
            return View(users.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.user.Find(id);
            //Usergroup 3 je InactiveUser
            user.UserGroup_idUserGroup = 3;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}