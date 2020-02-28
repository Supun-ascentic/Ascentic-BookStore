

namespace Ascentic.BookStore.Application.Interfaces
{
    using Ascentic.BookStore.Model.DTO;
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthorApplication:IBaseApplication<Author,AuthorDTO>
    {
        Task<IEnumerable<Author>> GetAuthorsWithBooks();

        Task<Author> GetAuthorAllDetails(int key);

    }
}




