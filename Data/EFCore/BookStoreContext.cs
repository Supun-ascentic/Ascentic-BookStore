using Microsoft.EntityFrameworkCore;
using Ascentic_BookStore.Models;
namespace Ascentic_BookStore.Data.EFCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ascentic_BookStore.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BookStoreContext : IdentityDbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* modelBuilder.Entity<BookAuthor>()
                 .HasKey(t => new { t.BookId, t.AuthorId });*/

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookAuthor)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pt => pt.Author)
                .WithMany(t => t.BookAuthor)
                .HasForeignKey(pt => pt.AuthorId);
        }


        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<BookRating> BookRating { get; set; }

        public DbSet<Category> Category { get; set; }

    }
}
