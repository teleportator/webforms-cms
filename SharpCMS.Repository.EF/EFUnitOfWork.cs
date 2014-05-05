using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistUpdateOf(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistCreationOf(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistDeletionOf(entity);
        }

        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }
    }
}
