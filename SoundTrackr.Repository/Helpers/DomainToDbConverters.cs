using SoundTrackr.Domain.Entities.SubTrack;
using SoundTrackr.Domain.Entities.Track;
using SoundTrackr.Domain.Entities.TrackStat;
using SoundTrackr.Domain.ValueObjects;
using SoundTrackr.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.Helpers
{
    public static class DomainToDbConverters
    {
        public static TrackStatDb ConvertToDatabase(this TrackStat ts)
        {
            if (ts != null)
            {
                // wkt = well known text coordinate
                // TODO: make 4326 configurable
                string wkt = String.Format("POINT({0} {1})", ts.Location.Longitude, ts.Location.Latitude);

                return new TrackStatDb
                {
                    Id = ts.Id,
                    Location = DbGeography.PointFromText(wkt, 4326),
                    Timestamp = ts.Timestamp
                };
            }
            return new TrackStatDb();
        }

        public static SubTrackDb ConvertToDatabase(this SubTrack st)
        {
            if (st != null)
            {
                var subTrack = new SubTrackDb()
                {
                    Id = st.Id,
                    StartTimestamp = st.StartTimestamp,
                    Artist = st.Artist,
                    Song = st.Song
                };
                foreach (TrackStat ts in st.TrackStats)
                {
                    subTrack.TrackStats.Add(ts.ConvertToDatabase());
                }
                return subTrack;
            };
            return new SubTrackDb() { TrackStats = new List<TrackStatDb>() };
        }

        public static TrackDb ConvertToDatabase(this Track track)
        {
            if (track != null)
            {
                TrackDb trackDb = new TrackDb()
                {
                    Id = track.Id,
                    Name = track.Name,
                    StartCity = track.StartCity,
                    StartState = track.StartState,
                    TrackStart = track.TrackStart,
                    TrackEnd = track.TrackEnd,
                    UserId = track.UserId,
                    SubTracks = new List<SubTrackDb>()
                };

                foreach (SubTrack st in track.SubTracks)
                {
                    trackDb.SubTracks.Add(st.ConvertToDatabase());
                }

                return trackDb;
            }
            return new TrackDb() { SubTracks = new List<SubTrackDb>() };
        }
    }
}
