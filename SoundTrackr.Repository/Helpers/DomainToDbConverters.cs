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
            // wkt = well known text coordinate
            // TODO: make 4326 configurable
            string wkt = String.Format("POINT({0} {1})", ts.Location.Longitude, ts.Location.Latitude);

            return new TrackStatDb
            {
                Artist = ts.Artist,
                Id = ts.Id,
                Location = DbGeography.PointFromText(wkt, 4326)
,
                Song = ts.Song,
                Timestamp = ts.Timestamp
            };
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
                    TrackStats = new List<TrackStatDb>()
                };

                foreach (TrackStat ts in track.TrackStats)
                {
                    trackDb.TrackStats.Add(ts.ConvertToDatabase());
                }

                return trackDb;
            }
            else
                return new TrackDb() { TrackStats = new List<TrackStatDb>() };
        }
    }
}
