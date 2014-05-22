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
    public class MatchController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /Match/

        public ActionResult Index()
        {
            var match = db.match.Include(m => m.footballteam).Include(m => m.footballteam1).Include(m => m.gameweek);
            return View(match.ToList());
        }

        //
        // GET: /Match/Details/5

        public ActionResult Details(int id = 0)
        {
            match match = db.match.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        //
        // GET: /Match/Create

        public ActionResult Create()
        {
            ViewBag.homeTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName");
            ViewBag.awayTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName");
            ViewBag.idGameWeek2 = new SelectList(db.gameweek, "idGameWeek", "gameweekName");
            return View();
        }

        //
        // POST: /Match/Create

        [HttpPost]
        public ActionResult Create(match match)
        {
            if (ModelState.IsValid)
            {
                db.match.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.homeTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.homeTeam);
            ViewBag.awayTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.awayTeam);
            ViewBag.idGameWeek2 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", match.idGameWeek2);
            return View(match);
        }

        //
        // GET: /Match/Edit/5

        public ActionResult Edit(int id = 0)
        {
            match match = db.match.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.homeTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.homeTeam);
            ViewBag.awayTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.awayTeam);
            ViewBag.idGameWeek2 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", match.idGameWeek2);
            return View(match);
        }

        //
        // POST: /Match/Edit/5

        [HttpPost]
        public ActionResult Edit(match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.homeTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.homeTeam);
            ViewBag.awayTeam = new SelectList(db.footballteam, "idFootballTeam", "teamName", match.awayTeam);
            ViewBag.idGameWeek2 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", match.idGameWeek2);
            return View(match);
        }

        //
        // GET: /Match/Delete/5

        public ActionResult Delete(int id = 0)
        {
            match match = db.match.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        //
        // POST: /Match/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            match match = db.match.Find(id);
            db.match.Remove(match);
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