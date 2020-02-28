namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBookRepository: IRepository<Book>
    {

          Task<List<Book>> GetBooksWithAllDetails();
          Task<Book> GetAllDetails(int id);
          Task<List<Book>> GetBooksSortedByTitle();
          Task<List<Book>> GetBooksSortedByAuthor();
    }
}
