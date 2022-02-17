using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage_2_Group_1.Models.UserViewModels
{
    public class UserEditViewModel
    {
        [Required]
        [Display(Name = "Social Security Number")]
        public long SSN { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
