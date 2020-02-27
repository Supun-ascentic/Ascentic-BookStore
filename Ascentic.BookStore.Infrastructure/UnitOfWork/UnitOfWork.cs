using Ascentic.BookStore.Infrastructure.DbContext;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Infrastructure.Repository;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
       
            public UnitOfWork(
            BookStoreDbContext context,
            IBookRepository bookRepository,
            IRatingRepository ratingRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository

        )
        {
            this.Context = context;
            this.BookRepository = bookRepository;
            this.RatingRepository = ratingRepository;
            this.AuthorRepository = authorRepository;
            this.CategoryRepository = categoryRepository;


        }

        public BookStoreDbContext Context { get; }

   

        public IBookRepository BookRepository { get; }

        public IAuthorRepository AuthorRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IRatingRepository RatingRepository { get; }


        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
