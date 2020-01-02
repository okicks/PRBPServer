using System;
using System.ComponentModel.DataAnnotations;

namespace Models.PostModels
{
    public class DeletePost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public int ThreadId { get; set; }
    }
}
