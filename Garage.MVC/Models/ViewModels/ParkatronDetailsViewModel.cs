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
        public IEnumerable<Vehicle> RegisteredVehicles { get; set; }
        public IEnumerable<ParkingSlot> ParkingSlots { get; set; }
        public IEnumerable<User> RegisteredUsers { get; set; }
        public IEnumerable<VehicleType> RegisteredVehicleTypes { get; set; }





    }
}
