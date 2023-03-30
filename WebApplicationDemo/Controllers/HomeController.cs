using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sessionValue = Session["SessionLogin_TEN"] != null ? Session["SessionLogin"].ToString() : string.Empty;
            if(string.IsNullOrEmpty(sessionValue))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.SessionValue = sessionValue;
            return View();
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
    }
}