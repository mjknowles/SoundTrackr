using Microsoft.AspNet.Identity.EntityFramework;
using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
using SoundTrackr.Domain.Entities.Track;
using SoundTrackr.Domain.Entities.User;
using SoundTrackr.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository
{
    public class SoundTrackrContext : IdentityDbContext<UserDb>
    {
        public SoundTrackrContext()
            : base("SoundTrackrContext") 
        {
            // Since application is layered, protect yourself from
            // lazy loading from a disposed of context
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<TrackDb> Tracks { get; set; }

        public static SoundTrackrContext Create()
        {
            return new SoundTrackrContext();
        }
    }
}
