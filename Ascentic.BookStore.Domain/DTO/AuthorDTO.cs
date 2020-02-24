using Ascentic.BookStore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Domain.DTO
{
    public class AuthorDTO: IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Birthplace { get; set; }
        public string Facts { get; set; }

        public List<BookAuthorDTO> BookAuthor { get; set; }
        public string PhotoURL { get; set; }
    }
}
