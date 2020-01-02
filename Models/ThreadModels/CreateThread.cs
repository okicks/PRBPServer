using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ThreadModels
{
    public class CreateThread
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
        public int CatagoryId { get; set; }
    }
}
