namespace Ascentic.BookStore.Model.Entity
{
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Rating : IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public double rating { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }


    }
}
