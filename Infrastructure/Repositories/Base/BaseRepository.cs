namespace DreamJob.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IDreamJobContext context;

        public BaseRepository(IDreamJobContext context)
        {
            this.context = context;
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
