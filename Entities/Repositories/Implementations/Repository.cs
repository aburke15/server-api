using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApi.Entities.Repositories.Interfaces;

namespace ServerApi.Entities.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ServerApiDbContext _context;

        protected Repository(ServerApiDbContext context) 
            => _context = context;

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get() 
            => _context.Set<TEntity>().ToList();

        public async Task<IEnumerable<TEntity>> GetAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public TEntity GetById(object key)
        {
            ValidateKey(key);
            return _context.Set<TEntity>().Find(key);
        }

        public async Task<TEntity> GetByIdAsync(object key)
        {
            ValidateKey(key);
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
            => _context.Set<TEntity>().Where(expression);

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        
        public async Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }
        
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            _context.SaveChanges();
        }
        
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        private static void ValidateKey(object key)
        {
            if (key is null) 
                throw new ArgumentNullException(nameof(key));
            
            if (key.GetType() != typeof(int))
                throw new InvalidOperationException($"Key ID must be of type {typeof(int)}");
        }
    }
}