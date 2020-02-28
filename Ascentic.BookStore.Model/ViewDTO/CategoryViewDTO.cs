using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Model.ViewDTO
{
    public class CategoryViewDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
