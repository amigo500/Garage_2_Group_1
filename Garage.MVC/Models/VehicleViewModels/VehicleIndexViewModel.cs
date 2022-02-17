namespace Garage_2_Group_1.Models.VehicleViewModels
{
    public record UserIndexViewModel (string VehicleType, string RegNr, ICollection<Vehicle> Vehicles);

}