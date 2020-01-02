using System.ComponentModel.DataAnnotations;

namespace Models.CategoryModels
{
    public class ReadCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
