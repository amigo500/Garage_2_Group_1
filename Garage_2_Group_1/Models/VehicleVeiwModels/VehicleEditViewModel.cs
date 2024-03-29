﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Please enter the registration number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid registration number")]
        [Remote(action: "CheckRegNr", controller: "Vehicles", AdditionalFields ="Id")]
        public string? RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleType Type { get; set; }

        [Display(Name = "Color")]
        public VehicleColor Color { get; set; }

        [Required(ErrorMessage = "Please enter the make")]
        public string? Make { get; set; }

        [Required(ErrorMessage = "Please enter the model")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Please enter the number of wheels")]
        [Display(Name = "Wheel Count")]
        [Range(0, 10, ErrorMessage = "The wheel count must be between 0 and 10")]
        public int WheelCount { get; set; }

        public string ParkingSlots { get; set; }

        public bool? EditedSuccesfully { get; set; }
    }
}
