using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerApi.AppData.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        Task AddRangeAsync(IEnumerable<T> entities);

        IEnumerable<T> Get();

        Task<IEnumerable<T>> GetAsync();

        T GetById(object key);

        Task<T> GetByIdAsync(object key);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void SaveChanges();
        
        Task SaveChangesAsync();
    }
}