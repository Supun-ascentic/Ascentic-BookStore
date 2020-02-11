using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ascentic_BookStore.Models;

namespace Ascentic_BookStore.Data
{
    public class Ascentic_BookStoreContext : DbContext
    {
        public Ascentic_BookStoreContext (DbContextOptions<Ascentic_BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Ascentic_BookStore.Models.Book> Book { get; set; }
    }
}
