using Garage_2_Group_1.Models.ViewModels;

namespace Garage_2_Group_1.Controllers
{
    public class StatisticsBuilder
    {
        private GarageContext2 _db;
        private ICollection<Vehicle>? _vehicles;
        public async Task<ParkatronDetailsViewModel> GetAllDataFromGarage(GarageContext2 db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            DoQueries();
            
            ParkatronDetailsViewModel _stats = new();
            _stats.NumberOfRegisteredUsers = await _db.User.CountAsync();
            _stats.RegisteredVehicleTypes = await GetVehicleTypeTuple();
            _stats.NumberOfRegisteredVehicles = await GetRegisteredVehicles();
            _stats.TotalWheels = await GetVehicleWheelCount();
            _stats.NumberOfParkedVehicles = await GetNumberOfParkedVehicle();
            _stats.EarnedTotals = await GetTotalEarnings();
            _stats.UsedParkingSlots = await GetNumberOfUsedParkingSlots();
            _stats.TotalGarageSpace = await _db.ParkingSlot.CountAsync();

            return _stats;
        }

        private void DoQueries()
        {
            
        }

        private async Task<int> GetNumberOfUsedParkingSlots()
        {
            var parkingSlots = await _db.ParkingSlot.ToListAsync();
            var usedParkingSlots = parkingSlots.Where(s => s.Vehicle != null).Count();
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

        private async Task<int> GetNumberOfParkedVehicle() // This code would work if the Vehicle got assigned a slot. But only the slot gets assigned.
        {
            var vehicles = await _db.Vehicle.ToListAsync();
            var parkedVehicles = vehicles.Where(v => v.ParkingSlots != null).Count();

            return parkedVehicles;

        }

        private async Task<int> GetVehicleWheelCount()
        {
            var vehicles = await _db.Vehicle.ToListAsync();
            var wheelCount = vehicles.Select(vehicle => vehicle.WheelCount).Sum();

            return wheelCount;
        }

        private async Task<int> GetRegisteredVehicles()
        {
            var vehicles = await _db.Vehicle.ToListAsync();
            return vehicles.Count();
        }

        public async Task<List<(string, int)>> GetVehicleTypeTuple()
        {
            var vehicles = await _db.Vehicle.ToListAsync();
            var vehicleTypes = await _db.VehicleType.ToListAsync();
            var vehicleTypeTuple = new List<(string, int)>();

            foreach (var item in vehicleTypes)
            {
                var name = item.Name;
                var count = vehicles.Where(t => t.VehicleType.Name == item.Name).Count();

                vehicleTypeTuple.Add((name, count));
            }

            return vehicleTypeTuple;
        }
    }
}
