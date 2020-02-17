using Ascentic.BookStore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Domain.DTO
{
    public class BookDTO : IBaseDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<BookAuthorDTO> BookAuthor { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
