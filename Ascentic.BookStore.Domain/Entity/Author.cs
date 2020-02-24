

namespace Ascentic.BookStore.Domain.Entity
{
    using Ascentic.BookStore.Domain.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        public string PhotoURL { get; set; }

    }
}
