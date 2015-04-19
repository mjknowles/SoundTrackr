using SoundTrackr.Service.Messaging.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Track
{
    public interface ITrackService
    {
        GetTrackResponse GetTrack(GetTrackRequest getTrackRequest);
        GetTracksResponse GetTracks(GetTracksRequest getTracksRequest);
    }
}
