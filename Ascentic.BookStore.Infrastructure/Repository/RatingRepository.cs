

namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RatingRepository : GenericRepository<BookRating, BookStoreDbContext>
    {
        private readonly BookStoreDbContext context;
        public RatingRepository(BookStoreDbContext context)
            : base(context)
        {
            this.context = context;
        }
        // We can add new methods specific to the movie repository here in the future

        public async Task<List<BookRating>> GetRatingByBookId(int Bookid)
        {
            return await this.context.Set<BookRating>()
                .Where(rating => rating.BookId == Bookid)
                .ToListAsync();
        }
    }
}


