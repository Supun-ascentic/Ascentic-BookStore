namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Domain.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookRepository : GenericRepository<Book, BookStoreDbContext>
    {

     
        private readonly BookStoreDbContext context;
        public BookRepository(BookStoreDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Book>> GetBooksWithAllDetails()
        {
            return await this.context.Set<Book>()
                .Include(book=> book.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.BookCategory)
                .ThenInclude(BookCategory => BookCategory.Category)
                .Include(book => book.Ratings)
                .ToListAsync();
        }

        public async Task<Book> GetAllDetails(int id)
        {
            return await context.Set<Book>().Include(book => book.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.BookCategory)
                .ThenInclude(BookCategory => BookCategory.Category)
                .Include(book => book.Ratings)
                .SingleOrDefaultAsync(i => i.ID == id);
        }

        public async Task<List<Book>> GetBooksSortedByTitle()
        {
            return await this.context.Set<Book>()
                .Include(book => book.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.BookCategory)
                .ThenInclude(BookCategory => BookCategory.Category)
                .Include(book => book.Ratings)
                .OrderBy(book => book.Title)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksSortedByAuthor()
        {
            var book= await this.context.Set<Book>()
                .Include(book => book.BookAuthor)
                .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.BookCategory)
                .ThenInclude(BookCategory => BookCategory.Category)
                .Include(book => book.Ratings)
                .ToListAsync();


            return book.OrderBy(book => (book.BookAuthor[0].Author.Name == null) ? string.Empty : book.BookAuthor[0].Author.Name).ToList();
        }

        // We can add new methods specific to the movie repository here in the future
    }
}


