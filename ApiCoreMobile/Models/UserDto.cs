using System.ComponentModel.DataAnnotations;

namespace ApiCoreMobile.Models
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "You Have Reached Maximum Length Of Charachters In Password")]
        public string Password { get; set; }
    }
    public class UserDto : LoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }




    }
}
