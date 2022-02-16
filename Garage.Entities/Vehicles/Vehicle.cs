using System.ComponentModel.DataAnnotations;


namespace Garage.Entities.Vehicles
{
    public class Vehicle
    {
        [Key]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string RegNr { get; set; }
        [Required]
        public VehicleColor Color { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int WheelCount { get; set; }
        [Required]
        public int UserSSN { get; set; }
        [Required]
        public User User { get; set; }

        public ICollection<ParkingSlot> ParkingSlots { get; set; } = new List<ParkingSlot>();

        [Required]
        public int VehicleTypeID { get; set; }
        public VehicleType VehicleType { get; set; }

        private Vehicle()
        {
            Make = null!;
            Model = null!;
            RegNr = null!;
            User = null!;
            VehicleType = null!;
        }

        public Vehicle(string make, string model, string regNr, User user, VehicleType vehicleType)
        {
            Make = make;
            Model = model;
            RegNr = regNr;
            User = user;
            VehicleType = vehicleType;
        }
    }
}