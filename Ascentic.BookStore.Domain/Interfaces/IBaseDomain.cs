using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Interfaces
{
    public interface IBaseDomain<IEntity>
    {
        Task<IEntity> Add(IEntity entity);

        void Delete(int key);

        void Update(int id, IEntity entity);

        Task<List<IEntity>> GetAll();

        Task<IEntity> Get(int key);

    }
}
