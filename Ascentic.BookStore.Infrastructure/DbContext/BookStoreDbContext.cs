
using Ascentic.BookStore.Model.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ascentic.BookStore.Infrastructure.DbContext
{
   

    public class BookStoreDbContext : IdentityDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
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
                .HasForeignKey(pt => pt.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pt => pt.Author)
                .WithMany(t => t.BookAuthor)
                .HasForeignKey(pt => pt.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<BookCategory>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookCategory)
                .HasForeignKey(pt => pt.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.BookCategory)
                .HasForeignKey(pt => pt.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<Rating> BookRating { get; set; }

        public DbSet<Category> Category { get; set; }

    }
}
