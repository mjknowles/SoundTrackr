using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.Track
{
    public interface ITrackRepoAccessor
    {
        Track GetTrack(int id);
        List<Track> GetTracksByUserId(string userId);
        List<Track> GetTracksByUserName(string userName);
    }
}
