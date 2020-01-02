using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CatagoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
