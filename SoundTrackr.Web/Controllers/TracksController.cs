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
using SoundTrackr.Web.DTOs;
using SoundTrackr.Web.Helpers.GeoJson;

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
            GetTracksResponse resp = _trackService.GetTracks(new GetTracksRequest { UserName = userName });
            return Request.BuildResponse(resp);

            /*return Request.CreateResponse(new TracksViewModel { TrackNames = new List<TrackListingViewModel> { 
                new TrackListingViewModel { Id = 1, Name = "Washington DC" },
                new TrackListingViewModel { Id = 2, Name = "Birmingham" },
                new TrackListingViewModel { Id = 3, Name = "Nashville" }
            }});*/
        }

        // GET: api/tracks/1
        [System.Web.Http.Route("{id:int}")]
        public HttpResponseMessage GetTrack(int id)
        {
            var resp = _trackService.GetTrack(new GetTrackRequest(id, User.Identity.GetUserId()));
            if(resp.Exception == null)
                return Request.BuildResponse(GeoJsonTrackBuilder.CreateTrack(resp));
            else
                return Request.BuildResponse(resp);

            /*
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
                { "stroke", "#fa946e" },
                { "stroke-opacity", 1 },
                { "stroke-width", 6 },
            };

            var feature1 = new Feature(new Point(new GeographicPosition("38.89784666877921","-77.0366048812866")), feature1Properties);
            var feature2 = new Feature(new Point(new GeographicPosition("38.88981361419182","-77.00905323028564")), feature2Properties);
            var feature3 = new Feature(new LineString(new List<IPosition>
            {
                new GeographicPosition("38.89873175227713", "-77.0366048812866"),
                new GeographicPosition("38.89876515143842", "-77.03364372253417"),
                new GeographicPosition("38.89549195896866", "-77.03364372253417"),
                new GeographicPosition("38.89549195896866", "-77.02982425689697"),
                new GeographicPosition("38.89387200688839", "-77.02400922775269"),
                new GeographicPosition("38.891416957534204","-77.01519012451172"),
                new GeographicPosition("38.892068305429156","-77.01521158218382"),
                new GeographicPosition("38.892051604275686","-77.00813055038452"),
                new GeographicPosition("38.89143365883688","-77.00832366943358"),
                new GeographicPosition("38.89082405874451","-77.00818419456482"),
                new GeographicPosition("38.88989712255097","-77.00815200805664")
            }), feature3Properties);

            var features = new List<Feature>();
            features.Add(feature1);
            features.Add(feature2);
            features.Add(feature3);

            var geoJson = new GeoJsonDTO { GeoJson = new FeatureCollection(features) };
            
            return Request.CreateResponse(HttpStatusCode.OK, geoJson);*/
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
            // TODO: remove this test string
            GetTracksResponse resp = _trackService.GetTracks(new GetTracksRequest("9feb9a5d-2906-42c5-adc1-9a106785f879"));
            return View(new TracksViewModel(resp));
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
