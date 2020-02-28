using Ascentic.BookStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Interfaces
{
    public interface IAuthorDomain: IBaseDomain<Author>
    {
        Task<List<Author>> GetAuthorsWithBooks();

        Task<Author> GetAuthorAllDetails(int key);

    }
}
