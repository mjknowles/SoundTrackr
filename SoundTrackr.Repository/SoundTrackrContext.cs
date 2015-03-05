using SoundTrackr.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository
{
    public class SoundTrackrContext : DbContext
    {
        public SoundTrackrContext()
            : base("GifAtMeContext") 
        {
            // Since application is layered, protect yourself from
            // lazy loading from a disposed of context
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<TrackDb> Tracks { get; set; }    
    }
}
