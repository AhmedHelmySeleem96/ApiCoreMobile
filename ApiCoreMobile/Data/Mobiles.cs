using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreMobile.Data
{
    public class Mobiles
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        [ForeignKey("Category")]    
        public int CategoryId { get; set; }
        public Category category { get; set; }
        
    }
}
