﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}
