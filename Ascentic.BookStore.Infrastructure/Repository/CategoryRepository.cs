
namespace Ascentic.BookStore.Infrastructure.Repository
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Infrastructure.DbContext;
    using Ascentic.BookStore.Infrastructure.Interfaces;

    public class CategoryRepository : GenericRepository<Category, BookStoreDbContext>,ICategoryRepository
    {
        public CategoryRepository(BookStoreDbContext context)
            : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}


