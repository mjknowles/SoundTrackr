using Microsoft.AspNet.Identity.EntityFramework;
using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
using SoundTrackr.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository
{
    public class SoundTrackrContext : DbContext, IUnitOfWork
    {
        public SoundTrackrContext()
            : base("SoundTrackrContext") 
        {
            // Since application is layered, protect yourself from
            // lazy loading from a disposed of context
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<TrackDb> Tracks { get; set; }

        public void RegisterInsertion(IAggregateRoot aggregateRoot)
        {
            this.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Added;
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot)
        {
            this.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Modified;
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot)
        {
            this.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
