using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage_2_Group_1.Models.UserViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [Display(Name = "Social Security Number")]
        public int SSN { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First name must be minimum two characters")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last name must be minimum two characters")]
        public string LastName { get; set; }
        

    }
}
