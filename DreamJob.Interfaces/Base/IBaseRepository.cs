namespace DreamJob.Infrastructure.Interfaces.Base
{
    using DreamJob.Domain.Models;
    using System.Collections.Generic;

    public interface IBaseRepository<T> where T:BaseEntity
    {
        T GetById(long id);
        void RemoveById(long id);
        void Save(T entity);
        void Save(IEnumerable<T> entityList);

    }
}
