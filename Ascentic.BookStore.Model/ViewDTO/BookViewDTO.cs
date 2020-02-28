using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Model.ViewDTO
{
    public class BookViewDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public List<BookCategoryViewDTO> BookCategory { get; set; }

        public List<BookAuthorViewDTO> BookAuthor { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string PhotoURL { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
