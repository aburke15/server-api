using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApi.AppData.Interfaces;
using ServerApi.Entities;

namespace ServerApi.AppData.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServerApiContext _context;

        protected Repository(ServerApiContext context) 
            => _context = context;

        public void Add(T entity) 
            => _context.Set<T>().Add(entity);
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Get() 
            => _context.Set<T>().ToList();

        public async Task<IEnumerable<T>> GetAsync()
            => await _context.Set<T>().ToListAsync();

        public T GetById(object key) 
            => _context.Set<T>().Find(key);

        public async Task<T> GetByIdAsync(object key) 
            => await _context.Set<T>().FindAsync(key);

        public void Remove(T entity) 
            => _context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) 
            => _context.Set<T>().RemoveRange(entities);

        public void Update(T entity) 
            => _context.Set<T>().Update(entity);

        public void UpdateRange(IEnumerable<T> entities) 
            => _context.Set<T>().UpdateRange(entities);

        public void SaveChanges() 
            => _context.SaveChanges();

        public async Task SaveChangesAsync() 
            => await _context.SaveChangesAsync();

        private static void ValidateKey(object key)
        {
            if (key is null) 
                throw new ArgumentNullException(nameof(key));
            
            if (key.GetType() != typeof(int))
                throw new InvalidOperationException($"Key ID must be of type {typeof(int)}");
        }
    }
}