namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book> Get(int id);

        Task<Book> Add(Book entity);

        Task<Book> Update(int id, Book entity);

        Task<Book> Delete(int id);
    }
}
