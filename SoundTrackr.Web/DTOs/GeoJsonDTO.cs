using GeoJSON.Net;
using GeoJSON.Net.Feature;
using SoundTrackr.Service.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.DTOs
{
    public class GeoJsonDTO : ServiceResponseBase
    {
        public List<GeoJsonDetails> GeoJsonLayers { get; set; }
    }

    public class GeoJsonDetails
    {
        public GeoJSONObject GeoJsonObject { get; set; }
        public string PopupContent { get; set; }
    }
}