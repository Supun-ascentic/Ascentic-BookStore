using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Interfaces
{
    public interface IBaseDomain
    {
        Task<IEntity> Add(IEntity entity);

        void Delete(int key);

        void Update(int key, IEntity entity);

        IEnumerable<IEntity> GetAll();

        IEntity Get(int key);

    }
}
