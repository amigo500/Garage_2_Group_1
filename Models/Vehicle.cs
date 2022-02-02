using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models
{
    public class Vehicle
    {

        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Enter the Vehicle Registration Number!")]
        [StringLength(6, MinimumLength = 6)]
        public string RegNr { get; set; } // visas
        
        [Display(Name = "Vehicle Type")]
        [Required]
        public VehicleType Type { get; set; } // visas
        public DateTime ArrivalTime { get; set; } // visas

        [Display(Name = "Color")]
        [Required]
        public VehicleColor Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int WheelCount { get; set; }

        public int GetVehicleSize()
        {
            int size = 0;
            switch (Type)
            {
                case VehicleType.Bus:
                    size = 2;
                    break;
                case VehicleType.Boat:
                    size = 3;
                    break;
                case VehicleType.Airplane:
                    size = 3;
                    break;
                case VehicleType.Car:
                    size = 1;
                    break;
                case VehicleType.Motorcycle:
                    size = 1;
                    break;
                default:
                    size = 1;
                    break;

            }return size;
        }

        
    }
         
}
