
namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Domain.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;


    public class CategoryRepository : GenericRepository<Category, BookStoreDbContext>
    {
        public CategoryRepository(BookStoreDbContext context)
            : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}


