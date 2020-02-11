// <copyright file="Book.cs" company="supun-ascentic">
// Copyright (c) supun-ascentic. All rights reserved.
// </copyright>
namespace Ascentic_BookStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Ascentic_BookStore.Data;

    public class Book : IEntity
        {
            public int Id { get; set; }

            [Required]
            [StringLength(60, MinimumLength = 3)]
            public string Title { get; set; }

            [Required]
            [StringLength(30)]
            public string Category { get; set; }

            [Required]
            [StringLength(100)]
            public string Author { get; set; }

            public double Price { get; set; }

            [Required]
            [StringLength(250)]
            public string Description { get; set; }
    }
}
