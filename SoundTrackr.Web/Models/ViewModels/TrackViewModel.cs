using GeoJSON.Net.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Models.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        public FeatureCollection FeatureCollection { get; set; }
    }
}