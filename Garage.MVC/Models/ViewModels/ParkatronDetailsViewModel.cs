using Garage.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Garage_2_Group_1.Models.ViewModels
#nullable disable  
{
    public class ParkatronDetailsViewModel
    {
        

        public int NumberOfParkedVehicles { get; set; }
        public int NumberOfRegisteredVehicles { get; set; }
        public int NumberOfRegisteredUsers { get; set; }
        public int ParkedVehicleGrossing { get; set; }
        public int EarnedTotals { get; set; }
        public int UsedParkingSlots { get; set; }
        public int TotalGarageSpace { get; set; }
        public ICollection<Vehicle> RegisteredVehicles { get; set; }
        public ICollection<ParkingSlot> ParkingSlots { get; set; }
        public ICollection<User> RegisteredUsers { get; set; }
        public ICollection<VehicleType> RegisteredVehicleTypes { get; set; }





    }
}
