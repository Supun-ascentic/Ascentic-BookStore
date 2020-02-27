
namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Infrastructure.Interfaces;
    using Ascentic.BookStore.Model.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public GenericRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public  async Task<List<TEntity>> GetAll()
        {
            var result= await context.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
           // context.Entry(entity).State = EntityState.Modified;
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

    }
}