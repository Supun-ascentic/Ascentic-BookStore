// <copyright file="Book.cs" company="supun-ascentic">
// Copyright (c) supun-ascentic. All rights reserved.
// </copyright>
namespace Ascentic_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ascentic_BookStore.Data;

    public class Book
        {
            [Required]
            public string BookId { get; set; }

            [Required]
            [StringLength(60, MinimumLength = 3)]
            public string Title { get; set; }

            public string Category { get; set; }

            public List<BookAuthor> BookAuthor { get; set; }

            public double Price { get; set; }

            [Required]
            [StringLength(250)]
            public string Description { get; set; }
    }
}
