namespace DreamJob.Infrastructure.Interfaces.Base
{
    using DreamJob.Domain.Models;

    public interface IBaseRepository<T> where T:BaseEntity
    {
        T GetById(int id);
        void RemoveById(int id);
        T Save(T entity);
    }
}
