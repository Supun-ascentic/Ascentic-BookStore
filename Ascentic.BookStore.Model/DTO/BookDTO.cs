using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Model.DTO
{
    public class BookDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public List<BookCategoryDTO> BookCategory { get; set; }

        public List<BookAuthorDTO> BookAuthor { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string PhotoURL { get; set; }
    }
}
