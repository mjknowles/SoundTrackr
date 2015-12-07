using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
using SoundTrackr.Repository.Context;
using SoundTrackr.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.Repositories
{
    public abstract class GenericDomainTypeRepository<DomainType, DbType, IdType>
        where DomainType : IAggregateRoot
        where DbType : GenericDb<IdType, DomainType>
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbContext _context;

        protected GenericDomainTypeRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;

            if (dbContextFactory == null) throw new ArgumentNullException("SoundTrackrContextFactory");
            _context = dbContextFactory.Create();
        }

        public virtual void Insert(DomainType item)
        {
            _unitOfWork.RegisterInsertion(item);
        }

        public virtual void Update(DomainType item)
        {
            _unitOfWork.RegisterUpdate(item);
        }

        public virtual void Delete(DomainType item)
        {
            _unitOfWork.RegisterDeletion(item);
        }

        public List<DomainType> ConvertToDomainList(List<DbType> dbs)
        {
            List<DomainType> dts = new List<DomainType>();
            if (dbs != null)
            {
                foreach (DbType db in dbs)
                {
                    dts.Add(db.ConvertToDomain());
                }
            }

            return dts;
        }

        public abstract DomainType FindById(IdType id);
    }
}
