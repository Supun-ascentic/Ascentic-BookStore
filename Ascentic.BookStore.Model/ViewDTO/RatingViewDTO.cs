using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ascentic.BookStore.Model.DTO
{
    public class RatingViewDTO : IBaseDTO
    {
        public int ID { get; set; }
        [Required]
        public double Rating { get; set; }

        [Required]
        public int BookId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
