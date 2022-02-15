using Garage.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Garage.Entities
{
    public class ParkingSlot
    {
        [Key]
        public int Id { get; set; }
        public string? VehicleRegNr { get; set; }
        public Vehicle Vehicle { get; set; } = new Vehicle();

    }
}