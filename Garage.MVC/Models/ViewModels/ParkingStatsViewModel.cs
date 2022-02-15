using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class ParkingStatsViewModel
    {
        public Dictionary<string, int> VehicleTypesData { get; set; }

        [Display(Name = "Total Amount of Wheels of All Parked Vehicles: ")]
        public int WheelCount { get; set; }

        [Display(Name = "Total Revenue of Currently Parked Vehicles: ")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public double TotalRevenue { get; set; }

    }
}
