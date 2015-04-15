using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository
{
    public class EfUnitOfWork
    {
        private DbContext _context;

        public EfUnitOfWork(IDbContextFactory dbContextFactory)
        {
            _context = dbContextFactory.Create();
        }

        public void RegisterInsertion(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Added;
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Modified;
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
