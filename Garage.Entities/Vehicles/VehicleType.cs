using System.ComponentModel.DataAnnotations;

namespace Garage.Entities.Vehicles
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Size { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public VehicleType()
        {
            Name = null!;
        }

        public VehicleType(string name)
        {
            Name = name;
        }

    }
}