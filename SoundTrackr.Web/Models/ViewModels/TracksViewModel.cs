using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Models.ViewModels
{
    public class TracksViewModel : ViewModelBase
    {
        public List<TrackListingViewModel> Tracks { get; set; }
    }
}