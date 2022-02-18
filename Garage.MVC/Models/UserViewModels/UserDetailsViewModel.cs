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
        public long UserSSN { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegNr { get; set; }
        public VehicleType Type { get; set; }


    }
}
