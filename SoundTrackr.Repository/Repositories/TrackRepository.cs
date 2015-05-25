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
using System.Data.Entity;

namespace SoundTrackr.Repository.Repositories
{
    public class TrackRepository : GenericDomainTypeRepository<Track, TrackDb, int>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory) : base(unitOfWork, dbContextFactory) { }

        public Track GetTrackById(int id)
        {
            return ConvertToDomain(_context.Set<TrackDb>().Include(t => t.TrackStats).SingleOrDefault(t => t.Id.Equals(id)));
        }

        public List<Track> GetAllTracks()
        {
            return ConvertToDomainList(_context.Set<TrackDb>().Include(t => t.TrackStats).ToList());
        }

        public List<Track> GetTracksByUserId(string userId)
        {
            return ConvertToDomainList(_context.Set<TrackDb>().Where(t => t.UserId == userId).Include(t => t.TrackStats).ToList());
        }

        public List<Track> GetTracksByUserName(string userName)
        {
            return ConvertToDomainList(_context.Set<TrackDb>().Where(t => t.User.UserName.ToLower().Equals(userName.ToLower())).Include(t => t.TrackStats).ToList());
        }

        public override Track ConvertToDomain(TrackDb trackDb)
        {
            if (trackDb != null)
            {
                Track track = new Track()
                {
                    Id = trackDb.Id,
                    Name = trackDb.Name,
                    TrackStart = trackDb.TrackStart,
                    TrackEnd = trackDb.TrackEnd,
                    StartCity = trackDb.StartCity,
                    StartState = trackDb.StartState,
                    UserId = trackDb.UserId,
                    TrackStats = new List<TrackStat>()
                };
                foreach (TrackStatDb tsdb in trackDb.TrackStats)
                {
                    track.TrackStats.Add(new TrackStat()
                    {
                        Id = tsdb.Id,
                        Song = tsdb.Song,
                        Timestamp = tsdb.Timestamp,
                        Artist = tsdb.Artist,
                        Location = new Location(Convert.ToString(tsdb.Location.Latitude), Convert.ToString(tsdb.Location.Longitude))
                    });
                }
                return track;
            }
            else
                return new Track{ TrackStats = new List<TrackStat>() };
        }

        public override TrackDb ConvertToDatabase(Track track)
        {
            TrackDb trackDb = new TrackDb()
            {
                Id = track.Id,
                Name = track.Name,
                TrackStart = track.TrackStart,
                TrackEnd = track.TrackEnd,
                StartCity = track.StartCity,
                StartState = track.StartState,
                UserId = track.UserId,
                TrackStats = new List<TrackStatDb>()
            };
            foreach (TrackStat ts in track.TrackStats)
            {
                // wkt = well known text coordinate
                // TODO: make 4326 configurable
                string wkt = String.Format("POINT({0} {1})", ts.Location.Longitude, ts.Location.Latitude);

                trackDb.TrackStats.Add(new TrackStatDb()
                {
                    Id = ts.Id,
                    Song = ts.Song,
                    Timestamp = ts.Timestamp,
                    Artist = ts.Artist,
                    Location = DbGeography.PointFromText(wkt, 4326)
                });
            }
            return trackDb;
        }
    }
}
