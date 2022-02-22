using Garage_2_Group_1.Models.ViewModels;
#nullable disable

namespace Garage_2_Group_1.Controllers
{
    public class StatisticsBuilder
    {
        private GarageContext2 _db;
        private ICollection<Vehicle> _vehicles;
        private ICollection<ParkingSlot> _parkingSlots;
        private ICollection<VehicleType> _vehicleTypes;

        public async Task<ParkatronDetailsViewModel> GetAllDataFromGarage(GarageContext2 db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            await DoQueries();
            
            ParkatronDetailsViewModel _stats = new();
            _stats.NumberOfRegisteredUsers = await _db.User.CountAsync();
            _stats.RegisteredVehicleTypes = await GetVehicleTypeTuple();
            _stats.NumberOfRegisteredVehicles = _vehicles.Count();
            _stats.TotalWheels = _vehicles.Select(vehicle => vehicle.WheelCount).Sum();
            _stats.NumberOfParkedVehicles = GetNumberOfParkedVehicle(); // This code would work if the Vehicle got assigned a slot. But only the slot gets assigned.
            _stats.EarnedTotals = await GetTotalEarnings();
            _stats.UsedParkingSlots = GetNumberOfUsedParkingSlots();
            _stats.TotalGarageSpace = await _db.ParkingSlot.CountAsync();

            return _stats;
        }

        private async Task<bool> DoQueries()
        {
            _vehicles = await _db.Vehicle.ToListAsync();
            _parkingSlots = await _db.ParkingSlot.ToListAsync();
            _vehicleTypes = await _db.VehicleType.ToListAsync();
            return true;
        }

        private int GetNumberOfUsedParkingSlots()
        {
            
            var usedParkingSlots = _parkingSlots.Where(s => s.Vehicle != null).Count();
            return usedParkingSlots;
        }

        private async Task<int> GetTotalEarnings()
        {
            var receipts = await _db.Receipt.ToListAsync();
            int total = 0;
            foreach (var r in receipts)
            {
                total += r.Price;
            }
            return total;
        }

        private int GetNumberOfParkedVehicle() // This code would work if the Vehicle got assigned a slot. But only the slot gets assigned.
        {
            var parkedVehicles = _vehicles.Where(v => v.ParkingSlots != null).Count();

            return parkedVehicles;
        }

        public async Task<List<(string, int)>> GetVehicleTypeTuple()
        {
            
            var vehicleTypes = await _db.VehicleType.ToListAsync();
            var vehicleTypeTuple = new List<(string, int)>();

            foreach (var item in vehicleTypes)
            {
                var name = item.Name;
                var count = _vehicles.Where(t => t.VehicleType.Name == item.Name).Count();

                vehicleTypeTuple.Add((name, count));
            }

            return vehicleTypeTuple;
        }
    }
}
