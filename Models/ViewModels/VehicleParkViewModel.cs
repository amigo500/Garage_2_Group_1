using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleParkViewModel
    {
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Please enter the registration number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid registration number")]
        [Remote(action: "CheckRegNr", controller: "Vehicles")]
        public string? RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Please pick a vehicle type")]
        public VehicleType? Type { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Please pick a color")]
        public VehicleColor? Color { get; set; }

        [Required(ErrorMessage = "Please enter the make")]
        public string? Make { get; set; }

        [Required(ErrorMessage = "Please enter the model")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Please enter the number of wheels")]
        [Display(Name = "Wheel Count")]
        [Range(3, 20, ErrorMessage = "The wheel count must be between 3 and 20")]
        public int WheelCount { get; set; }

        public bool? ParkedSuccesfully { get; set; }
    }
}
