namespace DreamJob.Infrastructure.Interfaces.Base
{
    using DreamJob.Domain.Models;
    using System.Collections.Generic;

    public interface IBaseRepository<T> where T:BaseEntity
    {
        T GetById(long id);
        
        void RemoveById(long id);
        void RemoveById(IEnumerable<long> ids);
        
        void Add(T entity);
        void Add(IEnumerable<T> entityList);

        void Update(T entity);
        void Update(IEnumerable<T> entityList);
    }
}
