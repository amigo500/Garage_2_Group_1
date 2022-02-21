using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage_2_Group_1.Models.UserViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [Display(Name = "Social Security Number")]
        [Remote(action: "CheckSSN", controller: "Users")]
        public long? SSN { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        [Remote(action: "CheckLastName", controller: "Users", AdditionalFields="FirstName")]
        public string LastName { get; set; }
    }


}
