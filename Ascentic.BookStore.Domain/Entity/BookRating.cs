namespace Ascentic.BookStore.Domain.Entity
{
    using Ascentic.BookStore.Domain.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookRating : IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }


    }
}
