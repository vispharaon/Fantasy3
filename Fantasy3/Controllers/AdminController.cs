using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantasy3.Models;
using WebMatrix.WebData;

namespace Fantasy3.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            fantasyEntities demoContext = new fantasyEntities();
            Teams student = new Teams();
            //fe.user.Where(a => a.email.Equals(model.UserName) && a.password.Equals(model.Password)).FirstOrDefault();
            //student.Team_Names = (from s in demoContext.footballteam
            //                      select new SelectListItem()
            //                      {
            //                          Text = s.teamName,
            //                          Value = Convert.ToString(s.idFootballTeam)
            //                      }).ToList<SelectListItem>();

            student.Team_Names = demoContext.footballteam.Select(data => new SelectListItem { Text = data.teamName, Value = "2" }).ToList<SelectListItem>();
            return View(student);

           // return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            //FormsAuthentication.SetAuthCookie("amar@amar.amar", true);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetTestAccounts(int id)
        {
            var jr = "{Id: 1, Name: 'Ime' }";

            return Content(jr, "application/json");
        }

        
        public ActionResult FillDropDwon()
        {
            fantasyEntities demoContext = new fantasyEntities();
            Teams student = new Teams();
            student.Team_Names = (from s in demoContext.footballteam
                                  select new SelectListItem()
                                  {
                                      Text = s.teamName,
                                      Value = s.idFootballTeam.ToString()
                                  }).ToList<SelectListItem>();
            return View(student);
        }

        [HttpPost]
        public ActionResult GetDivOfStudent(int id)
        {
            fantasyEntities demoContext = new fantasyEntities();

            var div = (from s in demoContext.footballteam
                       where s.idFootballTeam == id
                       select s.teamName).FirstOrDefault();
            return Content(div);
        } 

    }
}
