﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.VehicleVeiwModels
{
#nullable disable
    public class VehicleIndexViewModel
    {
        public string RegNr { get; set; }
        

        [Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType Type { get; set; }

        [Display(Name = "Owned By:")]
        public string FullName { get; set; }
        public long? UserSSN { get; set; }

        [Display(Name = "Color")]
        public VehicleColor? Color { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
        
        [Display(Name = "Wheel Count")]
        public int WheelCount { get; set; }


    }
}
