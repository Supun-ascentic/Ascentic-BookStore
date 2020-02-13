namespace Ascentic_BookStore.Models
{
    using Ascentic_BookStore.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Category : IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<Book> Book { get; set; }
    }
}
