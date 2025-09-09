using System.Linq.Expressions;

namespace PruebaTecnicaKaprielian.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> FindAllAsync();
    }
}
