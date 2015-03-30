﻿using SoundTrackr.Service.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoundTrackr.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITrackService _trackService; 

        public HomeController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
