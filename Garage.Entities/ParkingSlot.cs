using Garage.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Garage.Entities
{
    public class ParkingSlot
    {
        [Key]
        public int Id { get; set; }
        public string? VehicleRegNr { get; set; }
        public Vehicle Vehicle { get; set; }

        public ParkingSlot()
        {
            Vehicle = null!;
        }

        public ParkingSlot(int id, string regNr)
        {
            Id = id;
            VehicleRegNr = regNr;
            Vehicle = null!;
        }

    }
}