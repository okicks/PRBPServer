using System.ComponentModel.DataAnnotations;

namespace Models.CategoryModels
{
    public class DeleteCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
