using GeoJSON.Net.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Models.ViewModels
{
    public class TrackListingViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}