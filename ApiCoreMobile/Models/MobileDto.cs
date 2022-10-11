using ApiCoreMobile.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCoreMobile.Models
{
    public class MobileDto : CreateMobileDto
    {
        public int Id { get; set; }
        public CategoryDto category { get; set; }

    }
    public class CreateMobileDto
    {
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
