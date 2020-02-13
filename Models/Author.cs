

namespace Ascentic_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ascentic_BookStore.Data;

    public class Author: IEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string BirthPlace { get; set; }

        public List<BookAuthor> BookAuthor { get; set; }

        public string Facts { get; set; }

    }
}
