

namespace Ascentic.BookStore.Model.Entity
{
    using Ascentic.BookStore.Model.Interfaces;
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
