using System.ComponentModel.DataAnnotations;

namespace ApiCoreMobile.Models
{
    public class CategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
