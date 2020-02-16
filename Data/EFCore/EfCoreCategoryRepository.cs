namespace Ascentic_BookStore.Data.EFCore
{
    using Ascentic_BookStore.Data.EFCore;
    using Ascentic_BookStore.Models;

    public class EfCoreCategoryRepository : EfCoreRepository<Category, BookStoreContext>
    {
        public EfCoreCategoryRepository(BookStoreContext context)
            : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}


