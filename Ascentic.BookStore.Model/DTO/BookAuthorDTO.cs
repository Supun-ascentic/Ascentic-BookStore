using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascentic.BookStore.Model.DTO
{
    public class BookAuthorDTO:IBaseDTO
    {
        public int ID { get; set; }
        public int BookId { get; set; }

        public int AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
