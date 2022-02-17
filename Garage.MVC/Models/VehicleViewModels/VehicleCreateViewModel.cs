using Garage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.VehicleViewModels
{
    public class VehicleCreateViewModel
    {
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Please enter the registration number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid registration number")]
        [Remote(action: "CheckRegNr", controller: "Vehicles")]
        public string? RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Please pick a vehicle type")]
        public int? VehicleTypeID { get; set; }

        //public DateTime ArrivalTime { get; set; }

        [Display(Name = "Target User")]
        [Required(ErrorMessage = "Please pick a user")]
        public long? UserSSN { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Please pick a color")]
        public VehicleColor? Color { get; set; }

        [Required(ErrorMessage = "Please enter the make")]
        public string? Make { get; set; }

        [Required(ErrorMessage = "Please enter the model")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Please enter the number of wheels")]
        [Display(Name = "Wheel Count")]
        [Range(0, 10, ErrorMessage = "The wheel count must be between 0 and 10")]
        public int WheelCount { get; set; }

        public bool? CreatedSuccesfully { get; set; }
    }
}
