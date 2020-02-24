﻿namespace Ascentic.BookStore.Domain.Entity
{
    using Ascentic.BookStore.Domain.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookCategory : IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
