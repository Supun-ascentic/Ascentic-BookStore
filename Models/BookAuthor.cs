namespace Ascentic_BookStore.Models
{
    using Ascentic_BookStore.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookAuthor : IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
