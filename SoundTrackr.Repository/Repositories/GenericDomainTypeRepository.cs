using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
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
        where DomainType : EntityBase<IdType>, IAggregateRoot
        where DbType : GenericDb
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbContext _context;

        public GenericDomainTypeRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;

            if (dbContextFactory == null) throw new ArgumentNullException("DbContextFactory");
            _context = dbContextFactory.Create();
        }

        public virtual DomainType FindById(IdType id)
        {
            DomainType domainObj;
            domainObj = ConvertToDomain(_context.Set<DbType>().SingleOrDefault<DbType>(x => x.Id.Equals(id)));

            if (domainObj != null)
            {
                return domainObj;
            }
            return default(DomainType);
        }

        /// <summary>
        /// Example:
        /// IGenericDataRepository<Department> repository = new GenericAggregateRepository<Department>();
        /// IList<Department> departments = repository.GetAll(d => d.Employees);
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<DomainType> GetAll()
        {
            IQueryable<DbType> dbQuery = _context.Set<DbType>();
            List<DbType> dbList = dbQuery.AsNoTracking().ToList<DbType>();
            List<DomainType> domainList = new List<DomainType>();
            foreach(DbType dt in dbList)
            {
                domainList.Add(ConvertToDomain(dt));
            }
            return domainList;
        }

        public virtual void Insert(DomainType item)
        {
            _unitOfWork.RegisterInsertion(ConvertToDatabase(item));
        }

        public virtual void Update(DomainType item)
        {
            _unitOfWork.RegisterUpdate(ConvertToDatabase(item));
        }

        public virtual void Delete(DomainType item)
        {
            _unitOfWork.RegisterDeletion(ConvertToDatabase(item));
        }

        public virtual List<DomainType> ConvertToDomainList(List<DbType> dbs)
        {
            List<DomainType> domainList = new List<DomainType>();
            foreach(DbType db in dbs)
            {
                domainList.Add(ConvertToDomain(db));
            }
            return domainList;
        }

        public abstract DomainType ConvertToDomain(DbType db);
        public abstract DbType ConvertToDatabase(DomainType dom); 
    }
}
