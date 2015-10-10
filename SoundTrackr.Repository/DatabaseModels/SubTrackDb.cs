using SoundTrackr.Domain.Entities.SubTrack;
using SoundTrackr.Domain.Entities.TrackStat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class SubTrackDb : GenericDb<int, SubTrack>
    {
        public DateTime StartTimestamp { get; set; }
        public List<TrackStatDb> TrackStats { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }

        public override SubTrack ConvertToDomain()
        {
            var subTrack = new SubTrack
            {
                Id = Id,
                StartTimestamp = StartTimestamp,
                Song = Song,
                Artist = Artist,
                TrackStats = new List<TrackStat>()
            };

            foreach (TrackStatDb tsdb in TrackStats)
            {
                subTrack.TrackStats.Add(tsdb.ConvertToDomain());
            }

            return subTrack;
        }
    }
}
