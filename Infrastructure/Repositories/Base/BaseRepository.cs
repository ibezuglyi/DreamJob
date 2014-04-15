namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;
    using DreamJob.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected JobContext Context { get; set; }

        public BaseRepository(JobContext context)
        {
            this.Context = context;
        }
        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public void RemoveById(long id)
        {
            T entity = GetById(id);
            Context.Set<T>().Remove(entity);
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
