

namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ascentic.BookStore.Infrastructure.Interfaces;

    public class RatingRepository : GenericRepository<Rating, BookStoreDbContext>, IRatingRepository
    {
        private readonly BookStoreDbContext context;
        public RatingRepository(BookStoreDbContext context)
            : base(context)
        {
            this.context = context;
        }
        // We can add new methods specific to the movie repository here in the future

        public async Task<List<Rating>> GetRatingByBookId(int Bookid)
        {
            return await this.context.Set<Rating>()
                .Where(rating => rating.BookId == Bookid)
                .ToListAsync();
        }
    }
}


