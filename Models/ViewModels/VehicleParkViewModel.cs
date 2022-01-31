using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleParkViewModel
    {
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Enter the Vehicle Registration Number!")]
        [StringLength(6, MinimumLength = 6)]
        public string? RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public VehicleType Type { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Color")]
        [Required]
        public VehicleColor Color { get; set; }

        [Required]
        public string? Make { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        [Range(3, 20)]
        public int WheelCount { get; set; }
    }
}
