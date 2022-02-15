namespace Garage_2_Group_1.Models.UserViewModels
{
    public record UserIndexViewModel(int SSN, string Avatar, string NameFullName, string Membership, ICollection<Vehicle> Vehicles);

}
