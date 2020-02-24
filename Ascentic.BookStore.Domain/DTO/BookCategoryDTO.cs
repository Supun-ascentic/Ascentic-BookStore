using Ascentic.BookStore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascentic.BookStore.Domain.DTO
{
    public class BookCategoryDTO:IBaseDTO
    {
        public int ID { get; set; }
        public int BookId { get; set; }

        public int CategoryId { get; set; }
    }
}
