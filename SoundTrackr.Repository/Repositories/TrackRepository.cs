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
using SoundTrackr.Repository.Context;
using SoundTrackr.Repository.Helpers;

namespace SoundTrackr.Repository.Repositories
{
    public class TrackRepository : GenericDomainTypeRepository<Track, TrackDb, int>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork, IDbContextFactory soundTrackrContextFactory) : base(unitOfWork, soundTrackrContextFactory) { }

        public override Track FindById(int id)
        {
            return _context.Set<TrackDb>().Include(t => t.TrackStats).SingleOrDefault(t => t.Id.Equals(id)).ConvertToDomain();
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

    }
}
