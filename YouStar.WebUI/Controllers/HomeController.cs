using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouStar.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult FancySignUp()
        {
            return View();
        }

        public ActionResult FancyLogin()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }
    }
}