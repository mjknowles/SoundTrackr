using GeoJSON.Net;
using SoundTrackr.Service.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.DTOs
{
    public class GeoJsonDTO : ServiceResponseBase
    {
        public GeoJSONObject GeoJson { get; set; }
    }
}