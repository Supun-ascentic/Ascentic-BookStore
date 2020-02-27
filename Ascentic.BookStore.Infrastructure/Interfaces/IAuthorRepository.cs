namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();

        Task<Author> Get(int id);

        Task<Author> Add(Author entity);

        Task<Author> Update(int id, Author entity);

        Task<Author> Delete(int id);
    }
}
