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

        private ParkingSlot()
        {
            Vehicle = null!;
        }

        public ParkingSlot(string? regNr)
        {
            VehicleRegNr = regNr;
            Vehicle = null!;
        }

        public ParkingSlot(int id, string? regNr)
        {
            Id = id;
            VehicleRegNr = regNr;
            Vehicle = null!;
        }

    }
}