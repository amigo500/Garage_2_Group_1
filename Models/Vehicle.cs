namespace Garage_2_Group_1.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; } // visas
        public VehicleType Type { get; set; } // visas
        public DateTime ArrivalTime { get; } // visas
        public VehicleColor Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int WheelCount { get; set; }






    }
}
