namespace DreamJob.Infrastructure.Repositories.Base
{
    using System.Collections.Generic;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;
    using DreamJob.Repositories;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected JobContext Context { get; set; }

        public BaseRepository(JobContext context)
        {
            this.Context = context;
        }

        public T GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveById(IEnumerable<long> ids)
        {
            throw new System.NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(IEnumerable<T> entityList)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IEnumerable<T> entityList)
        {
            throw new System.NotImplementedException();
        }
    }
}
