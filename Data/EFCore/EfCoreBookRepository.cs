namespace Ascentic_BookStore.Data.EFCore
{
    using Ascentic_BookStore.Data.EFCore;
    using Ascentic_BookStore.Models;

    public class EfCoreBookRepository : EfCoreRepository<Book, BookStoreContext>
    {
        public EfCoreBookRepository(BookStoreContext context)
            : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}


