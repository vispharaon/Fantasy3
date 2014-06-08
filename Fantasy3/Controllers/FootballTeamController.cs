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
    public class FootballTeamController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /FootballTeam/

        public ActionResult Index()
        {
            return View(db.footballteam.ToList());
        }

        //
        // GET: /FootballTeam/Details/5

        public ActionResult Details(int id = 0)
        {
            footballteam footballteam = db.footballteam.Find(id);
            if (footballteam == null)
            {
                return HttpNotFound();
            }
            return View(footballteam);
        }

        //
        // GET: /FootballTeam/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FootballTeam/Create

        [HttpPost]
        public ActionResult Create(footballteam footballteam)
        {
            if (ModelState.IsValid)
            {
                db.footballteam.Add(footballteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footballteam);
        }

        //
        // GET: /FootballTeam/Edit/5

        public ActionResult Edit(int id = 0)
        {
            footballteam footballteam = db.footballteam.Find(id);
            if (footballteam == null)
            {
                return HttpNotFound();
            }
            return View(footballteam);
        }

        //
        // POST: /FootballTeam/Edit/5

        [HttpPost]
        public ActionResult Edit(footballteam footballteam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footballteam);
        }

        //
        // GET: /FootballTeam/Delete/5

        public ActionResult Delete(int id = 0)
        {
            footballteam footballteam = db.footballteam.Find(id);
            if (footballteam == null)
            {
                return HttpNotFound();
            }
            return View(footballteam);
        }

        //
        // POST: /FootballTeam/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            footballteam footballteam = db.footballteam.Find(id);
            db.footballteam.Remove(footballteam);
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