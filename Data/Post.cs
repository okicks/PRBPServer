using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [ForeignKey(nameof(Thread))]
        public int ThreadId { get; set; }

        public virtual Thread Thread { get; set; }

        [Required]
        public bool Edited { get; set; }
    }
}
