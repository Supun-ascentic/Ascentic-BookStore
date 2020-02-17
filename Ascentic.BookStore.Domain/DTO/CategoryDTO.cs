using Ascentic.BookStore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Domain.DTO
{
    public class CategoryDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
