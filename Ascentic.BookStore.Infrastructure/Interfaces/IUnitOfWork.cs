

using System.Threading.Tasks;

namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IRatingRepository RatingRepository { get; }

        Task<int> SaveChangesAsync();

        void SaveChanges();
    }
}
