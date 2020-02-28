namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAuthorRepository: IRepository<Author>
    {

        Task<List<Author>> GetAuthorsWithBooks();
        Task<Author> GetAuthorAllDetails(int id);
    }
}
