using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.UserViewModels
{
#nullable disable
    public class UserDetailsViewModel
    {
        [Display(Name = "Social Security Number")]
        public long SSN { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Registered Vehicles")]
        public int RegisteredVehiclesAmount { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }


    }
}
