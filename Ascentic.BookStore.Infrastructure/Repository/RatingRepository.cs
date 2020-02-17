

namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Domain.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;
    public class RatingRepository : GenericRepository<BookRating, BookStoreDbContext>
    {
        public RatingRepository(BookStoreDbContext context)
            : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}


