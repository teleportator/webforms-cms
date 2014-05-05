using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        #region Fields
        private IUnitOfWork _uow;
        #endregion

        #region .Ctor
        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Methods
        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
        }

        public abstract IQueryable<T> GetObjectSet();

        public abstract string GetEntitySetName();

        public abstract T FindBy(EntityKey id);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        public void SaveContext()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().AddObject(GetEntitySetName(), entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().DeleteObject(entity);
        }
        #endregion
    }
}
