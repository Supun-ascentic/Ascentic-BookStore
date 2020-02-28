

namespace Ascentic.BookStore.Application.Interfaces
{
    using Ascentic.BookStore.Model.DTO;
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.ViewDTO;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBookApplication : IBaseApplication<Book, BookDTO>
    {
        Task<IEnumerable<Book>> GetBooksWithAllDetails();

        Task<IEnumerable<Book>> GetBooksSortedByAuthor();

        Task<IEnumerable<Book>> GetBooksSortedByTitle();

        Task<Book> GetAllDetails(int key);

    }
}




