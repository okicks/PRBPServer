using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ThreadModels
{
    public class UpdateThread
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
