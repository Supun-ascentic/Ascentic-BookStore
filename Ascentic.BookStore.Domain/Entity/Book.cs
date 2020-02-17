// <copyright file="Book.cs" company="supun-ascentic">
// Copyright (c) supun-ascentic. All rights reserved.
// </copyright>
namespace Ascentic.BookStore.Domain.Entity
{
    using Ascentic.BookStore.Domain.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book : IEntity
    {
            [Key]
            [Required]
            public int ID { get; set; }

            [Required]
            [StringLength(60, MinimumLength = 3)]
            public string Title { get; set; }

            [Required]
            public int CategoryId { get; set; }

            public Category Category { get; set; }

            public List<BookRating> Ratings { get; set; }

            public List<BookAuthor> BookAuthor { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public double Price { get; set; }

            public string Description { get; set; }
    }
}
