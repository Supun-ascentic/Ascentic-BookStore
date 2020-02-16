namespace Ascentic_BookStore.Data.EFCore
{
    using Ascentic_BookStore.Data.EFCore;
    using Ascentic_BookStore.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EfCoreAuthorRepository : EfCoreRepository<Author, BookStoreContext>
    {
        private readonly BookStoreContext context;
        public EfCoreAuthorRepository(BookStoreContext context)
            : base(context)
        {
            this.context = context;
        }
        // We can add new methods specific to the movie repository here in the future


        public async Task<List<Author>> GetAuthorsWithBooks()
        {
            return await this.context.Set<Author>()
                .Include(author => author.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Book)
                .ToListAsync();
        }
    }
}


