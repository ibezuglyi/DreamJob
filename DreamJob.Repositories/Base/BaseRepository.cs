namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;
    using System;
    using System.Collections.Generic;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public object persistenceContext { get; set; }

        public BaseRepository(object persistenceContext)
        {
            this.persistenceContext = persistenceContext;
        }
        public T GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<T> entityList)
        {
            throw new NotImplementedException();
        }


    }
}
