using System;
using System.ComponentModel.DataAnnotations;

namespace Models.PostModels
{
    public class UpdatePost
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
