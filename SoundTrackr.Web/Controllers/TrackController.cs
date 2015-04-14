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

namespace SoundTrackr.Web.Controllers
{
    [RoutePrefix("api/tracks")]
    public class TrackController : ApiController
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            if (trackService == null) throw new ArgumentNullException("Track service in track controller");
            _trackService = trackService;
        }
        // GET: api/gifentries
        [Route("")]
        public HttpResponseMessage GetTracks()
        {
            ServiceResponseBase resp = _trackService.GetTracks(new GetTracksRequest(User.Identity.GetUserId()));
            return Request.BuildResponse(resp);
        }

    }
}
