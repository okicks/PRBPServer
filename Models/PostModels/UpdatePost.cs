﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Models.PostModels
{
    public class UpdatePost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ThreadId { get; set; }
    }
}
