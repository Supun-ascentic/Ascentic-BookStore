namespace Ascentic_BookStore.Data.EFCore
{
    using Ascentic_BookStore.Data.EFCore;
    using Ascentic_BookStore.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EfCoreBookRepository : EfCoreRepository<Book, BookStoreContext>
    {

     
        private readonly BookStoreContext context;
        public EfCoreBookRepository(BookStoreContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Book>> GetBooksWithAllDetails()
        {
            return await this.context.Set<Book>()
                .Include(book=> book.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.Category)
                .Include(book => book.Ratings)
                .ToListAsync();
        } 
        // We can add new methods specific to the movie repository here in the future
    }
}


