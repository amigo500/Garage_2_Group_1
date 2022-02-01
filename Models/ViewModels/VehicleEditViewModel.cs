using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        public string? RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Please pick a vehicle type")]
        public VehicleType? Type { get; set; }

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

        public bool? EditedSuccesfully { get; set; }
    }
}
