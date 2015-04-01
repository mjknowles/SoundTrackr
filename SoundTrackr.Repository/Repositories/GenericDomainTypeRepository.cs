using SoundTrackr.Common.Domain;
using SoundTrackr.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.Repositories
{
    public abstract class GenericDomainTypeRepository<DomainType, IdType>
        where DomainType : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        internal SoundTrackrContext _context;

        public GenericDomainTypeRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;

            if (dbContextFactory == null) throw new ArgumentNullException("DbConntextFactory");
            _context = dbContextFactory.Create();
        }

        public virtual DomainType FindById(IdType id)
        {
            DomainType domainObj;
            domainObj = _context.Set<DomainType>().Find(id);

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
        public virtual IEnumerable<DomainType> GetAll(params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            List<DomainType> list;
            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

            //Apply eager loading
            foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<DomainType>();
            return list;
        }

        public virtual IList<DomainType> GetList(Func<DomainType, bool> where,
            params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            List<DomainType> list;

            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

            //Apply eager loading
            foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<DomainType>();
            return list;
        }

        public virtual DomainType GetSingle(Func<DomainType, bool> where, int index,
             params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            DomainType item = null;
            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

                //Apply eager loading
                foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .Where(where)
                    .ElementAtOrDefault(index); ; //Apply where clause
            return item;
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
    }
}
