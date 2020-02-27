namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRatingRepository
    {
        Task<List<Rating>> GetAll();

        Task<Rating> Get(int id);

        Task<Rating> Add(Rating entity);

        Task<Rating> Update(int id, Rating entity);

        Task<Rating> Delete(int id);
    }
}
