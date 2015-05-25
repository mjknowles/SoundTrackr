using SoundTrackr.Service.DTOs;
using SoundTrackr.Service.Messaging.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Models.ViewModels
{
    public class TracksViewModel : ViewModelBase
    {
        public TracksViewModel() { }
        public TracksViewModel(GetTracksResponse resp)
        {
            TrackNames = new List<TrackListingViewModel>();
            if (resp.Tracks != null)
            {
                foreach (TrackDTO track in resp.Tracks)
                {
                    TrackNames.Add(new TrackListingViewModel { Id = track.Id, Name = track.Name });
                }
            }
        }
        public List<TrackListingViewModel> TrackNames { get; set; }
    }
}