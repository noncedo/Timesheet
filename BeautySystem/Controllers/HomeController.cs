using BeautySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       //[CustomAuthenticationFilter]
        public ActionResult Index()
        {
            var model = db.Services.Take(4).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                Employee user = context.Employees.Where(u => u.Email == employee.Email && u.IdNumber == employee.IdNumber).FirstOrDefault();

                if (user != null)
                {
                    Session["Email"] = user.Email;
                    Session["IdNumber"] = user.IdNumber;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Error in login";
                }
            }            
            return View();
        }        
    }
}