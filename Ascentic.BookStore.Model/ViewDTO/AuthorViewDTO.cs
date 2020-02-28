using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Model.ViewDTO
{
    public class AuthorViewDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Birthplace { get; set; }
        public string Facts { get; set; }

        public List<BookAuthorViewDTO> BookAuthor { get; set; }
        public string PhotoURL { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
