using SoundTrackr.Service.Messaging;
using SoundTrackr.Service.Messaging.Track;
using SoundTrackr.Service.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SoundTrackr.Web.Helpers;
using System.Web.Mvc;
using SoundTrackr.Service.DTOs;

namespace SoundTrackr.Web.Controllers.API
{
    [System.Web.Http.RoutePrefix("api/tracks")]
    public class TracksController : ApiController
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            if (trackService == null) throw new ArgumentNullException("Track service in track controller");
            _trackService = trackService;
        }

        // GET: api/gifentries
        [System.Web.Http.Route("")]
        public HttpResponseMessage GetTracks()
        {
            GetTrackResponse resp = _trackService.GetTracks(new GetTracksRequest(User.Identity.GetUserId()));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries
        [System.Web.Http.Route("{userName}")]
        public HttpResponseMessage GetTracks(string userName)
        {
            GetTrackResponse resp = _trackService.GetTracks(new GetTracksRequest { UserName = userName });
            return Request.BuildResponse(resp);
        }
    }
}

namespace SoundTrackr.Web.Controllers.MVC
{
    public class TracksController : Controller
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            if (trackService == null) throw new ArgumentNullException("Track service in track controller");
            _trackService = trackService;
        }

        // GET: Tracks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            return View(new TrackDTO());
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackDTO trackDTO = new TrackDTO();
            if (trackDTO == null)
            {
                return HttpNotFound();
            }
            return View(new TrackDTO());
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackDTO trackDTO = new TrackDTO();
            if (trackDTO == null)
            {
                return HttpNotFound();
            }
            return View(trackDTO);
        }
    }
}
