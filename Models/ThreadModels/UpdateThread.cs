using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ThreadModels
{
    public class UpdateThread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
