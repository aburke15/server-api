using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerApi.Entities.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Get();

        Task<IEnumerable<TEntity>> GetAsync();

        TEntity GetById(object key);

        Task<TEntity> GetByIdAsync(object key);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void SaveChanges();
        
        Task SaveChangesAsync();
    }
}