﻿using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.UserViewModels
{
#nullable disable
    public class UserDetailsViewModel
    {
        [Display(Name = "Social Security Number")]
        public long SSN { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Display(Name = "Registered Vehicles")]
        public int RegisteredVehiclesAmount { get; set; } 
        public string Avatar { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public string Membership { get; set; }
        public long UserSSN { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegNr { get; set; }
        


    }
}
