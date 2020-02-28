using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascentic.BookStore.Model.ViewDTO
{
    public class BookAuthorViewDTO : IBaseDTO
    {
        public int ID { get; set; }
        public int BookId { get; set; }
        public List<BookDTO> Book { get; set; }
        public List<AuthorDTO> Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
