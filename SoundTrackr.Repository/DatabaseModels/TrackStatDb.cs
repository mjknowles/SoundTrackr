using SoundTrackr.Common.Domain;
using SoundTrackr.Domain.Entities.TrackStat;
using SoundTrackr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class TrackStatDb : GenericDb<int, TrackStat>
    {
        public string Song { get; set; }
        public string Artist { get; set; }
        public DbGeography Location { get; set; }
        public DateTime Timestamp { get; set; }

        public override TrackStat ConvertToDomain()
        {
            return new TrackStat
            {
                Artist = Artist,
                Id = Id,
                Location = new Location(Convert.ToString(Location.Latitude), Convert.ToString(Location.Longitude)),
                Song = Song,
                Timestamp = Timestamp
            };
        }
    }
}
