using System.ComponentModel.DataAnnotations;

namespace Models.CategoryModels
{
    public class UpdateCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
