using SoundTrackr.Common.UnitOfWork;
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

namespace SoundTrackr.Repository.Repositories
{
    public class TrackRepository : GenericDomainTypeRepository<Track, TrackDb, int>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory) : base(unitOfWork, dbContextFactory) { }

        private override Track ConvertToDomain(TrackDb trackDb)
        {
            Track track = new Track()
            {
                TrackStart = trackDb.TrackStart,
                TrackEnd = trackDb.TrackEnd,
                StartCity = trackDb.StartCity,
                StartState = trackDb.StartState
            };
            foreach(TrackStatDb tsdb in trackDb.TrackStats)
            {
                track.TrackStats.Add(new TrackStat()
                {
                    Song = tsdb.Song,
                    Timestamp = tsdb.Timestamp,
                    Artist = tsdb.Artist,
                    Location = new Location(Convert.ToString(tsdb.Location.Latitude), Convert.ToString(tsdb.Location.Longitude))
                });
            }
            return track;
        }

        private override Track ConvertToDatabase(Track track)
        {
            TrackDb trackDb = new TrackDb()
            {
                TrackStart = track.TrackStart,
                TrackEnd = track.TrackEnd,
                StartCity = track.StartCity,
                StartState = track.StartState
            };
            foreach (TrackStat ts in track.TrackStats)
            {
                // wkt = well known text coordinate
                // TODO: make 4326 configurable
                string wkt = String.Format("POINT({0} {1})", ts.Location.Longitude, ts.Location.Latitude);

                trackDb.TrackStats.Add(new TrackStatDb()
                {
                    Song = ts.Song,
                    Timestamp = ts.Timestamp,
                    Artist = ts.Artist,
                    Location = DbGeography.PointFromText(wkt, 4326)
                });
            }
            return track;
        }
    }
}
