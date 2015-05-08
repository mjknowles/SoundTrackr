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
using SoundTrackr.Web.Models.ViewModels;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

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

        // GET: api/tracks
        [System.Web.Http.Route("")]
        public HttpResponseMessage GetTracks()
        {
            GetTracksResponse resp = _trackService.GetTracks(new GetTracksRequest(User.Identity.GetUserId()));
            return Request.BuildResponse(resp);
        }
        

        // GET: api/tracks/user1
        [System.Web.Http.Route("{userName}")]
        public HttpResponseMessage GetTracks(string userName)
        {
            //GetTrackResponse resp = _trackService.GetTracks(new GetTracksRequest { UserName = userName });
            //return Request.BuildResponse(resp);

            return Request.CreateResponse(new TracksViewModel { Tracks = new List<TrackListingViewModel> { 
                new TrackListingViewModel { Id = 1, Name = "Washington DC" },
                new TrackListingViewModel { Id = 2, Name = "Birmingham" },
                new TrackListingViewModel { Id = 3, Name = "Nashville" }
            }});
        }

        // GET: api/tracks/1
        [System.Web.Http.Route("{id}")]
        public HttpResponseMessage GetTrack(int id)
        {
            //GetTrackResponse resp = _trackService.GetTrack(new GetTrackRequest(id, User.Identity.GetUserId()));
            //return Request.BuildResponse(resp);

            var feature1Properties = new Dictionary<string, object> { 
                { "title", "The White House" },
                { "marker-color", "#9c89cc" },
                { "marker-size", "medium" },
                { "marker-symbol", "building" }
            };
            var feature2Properties = new Dictionary<string, object> { 
                { "title", "U.S. Capitol" },
                { "marker-color", "#9c89cc" },
                { "marker-size", "medium" },
                { "marker-symbol", "town-hall" }
            };
            var feature3Properties = new Dictionary<string, object> { 
                { "stroke", "U.S. Capitol" },
                { "stroke-opacity", 1 },
                { "stroke-width", 6 },
            };

            var feature1 = new Feature(new Point(new GeographicPosition("-77.0366048812866", "38.89784666877921")), feature1Properties);
            var feature2 = new Feature(new Point(new GeographicPosition("-77.00905323028564", "38.88981361419182")), feature2Properties);
            var feature3 = new Feature(new LineString(new List<IPosition>
            {
                new GeographicPosition("-77.0366048812866", "38.89873175227713"),
                new GeographicPosition("-77.03364372253417", "38.89876515143842"),
                new GeographicPosition("-77.03364372253417", "38.89549195896866"),
                new GeographicPosition("-77.02982425689697", "38.89549195896866"),
                new GeographicPosition("-77.02400922775269", "38.89387200688839"),
                new GeographicPosition("-77.01519012451172", "38.891416957534204"),
                new GeographicPosition("-77.01521158218382", "38.892068305429156"),
                new GeographicPosition("-77.00813055038452", "38.892051604275686"),
                new GeographicPosition("-77.00832366943358", "38.89143365883688"),
                new GeographicPosition("-77.00818419456482", "38.89082405874451"),
                new GeographicPosition("-77.00815200805664", "38.88989712255097")
            }), feature3Properties);

            var features = new List<Feature>();
            features.Add(feature1);
            features.Add(feature2);
            features.Add(feature3);

            var fc = new FeatureCollection(features);

            return Request.CreateResponse(HttpStatusCode.OK, fc);
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
