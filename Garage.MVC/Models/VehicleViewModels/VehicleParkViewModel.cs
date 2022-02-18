using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.VehicleViewModels
{
    public class VehicleParkViewModel
    {
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Please enter the registration number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid registration number")]
        [Remote(action: "Parkable", controller: "Vehicles")]
        public string? RegNr { get; set; }

        public bool? ParkedSuccesfully { get; set; }
    }
}
