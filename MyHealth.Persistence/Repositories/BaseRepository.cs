﻿using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;

namespace MyHealth.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(dynamic id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is not null) return entity;
            else throw new NullReferenceException();
        }

        public async Task<dynamic> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity!);

            await _dbContext.SaveChangesAsync();
        }
    }
}