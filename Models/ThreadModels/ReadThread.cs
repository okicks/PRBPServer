using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ThreadModels
{
    public class ReadThread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
