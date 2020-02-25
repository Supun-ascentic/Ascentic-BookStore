using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    class BaseDomain : IBaseDomain
    {
        public Task<IEntity> Add(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEntity Get(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int key, IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
