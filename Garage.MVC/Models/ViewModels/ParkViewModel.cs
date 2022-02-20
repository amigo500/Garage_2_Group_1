namespace Garage_2_Group_1.Models.ViewModels
{
    public class ParkViewModel
    {
        public string RegNr { get; set; } = string.Empty;
        public string?[]? ParkingSlots { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
