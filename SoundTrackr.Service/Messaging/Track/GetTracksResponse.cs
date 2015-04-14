using SoundTrackr.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Messaging.Track
{
    public class GetTracksResponse : ServiceResponseBase
    {
        public List<TrackDTO> Tracks { get; set; }
    }
}
