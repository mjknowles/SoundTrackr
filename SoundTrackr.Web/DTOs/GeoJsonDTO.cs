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
        public GeoJsonDTO() : base()
        {
            GeoJsonFeatures = new FeatureCollection();
        }

        public FeatureCollection GeoJsonFeatures { get; set; }
    }
}