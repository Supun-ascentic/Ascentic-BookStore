namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> Get(int id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(int id, TEntity entity);

        Task<TEntity> Delete(int id);
    }
}
