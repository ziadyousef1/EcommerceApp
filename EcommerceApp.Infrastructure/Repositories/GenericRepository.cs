using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Infrastructure.Data;
using EcommerceApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGeneric<TEntity> where TEntity : class
    {
        public async Task<int> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
           var entity = await context.Set<TEntity>().FindAsync(id) 
                ?? throw new ItemNotFoundException($"Entity with id {id} not found");
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return context.Set<TEntity>().AsNoTracking().ToListAsync();
            
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
           var result = await context.Set<TEntity>().FindAsync(id);
            return result ?? throw new ItemNotFoundException($"Entity with id {id} not found");
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            var result = context.Set<TEntity>().Update(entity);
            return context.SaveChangesAsync();


        }
    }
}
