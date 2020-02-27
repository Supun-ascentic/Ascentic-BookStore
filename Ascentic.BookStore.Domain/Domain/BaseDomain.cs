using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    public abstract class BaseDomain<TEntity> : IBaseDomain<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseDomain(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
