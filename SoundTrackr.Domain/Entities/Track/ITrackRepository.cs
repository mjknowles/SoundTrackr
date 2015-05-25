using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.Track
{
    public interface ITrackRepository : IAggregateRootRepository<Track, int>
    {
        Track GetTrackById(int id);
        List<Track> GetAllTracks();
        List<Track> GetTracksByUserId(string userId);
        List<Track> GetTracksByUserName(string userName);
    }
}
