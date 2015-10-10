using SoundTrackr.Service.Track;
using SoundTrackr.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoundTrackr.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){   }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Example1()
        {
            return View();
        }

        public ActionResult Example2()
        {
            return View();
        }

        public ActionResult Example3()
        {
            return View();
        }
    }
}
