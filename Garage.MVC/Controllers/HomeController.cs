using AutoMapper;
using Garage_2_Group_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garage_2_Group_1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly GarageContext2 _db;
        private IMapper mapper;
        private GarageContext2 db;

        public HomeController(GarageContext2 context, IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
        }



        public async Task<IActionResult> Index()
        {
            var model = GetAllDataFromGarage();
            return View(await model);
        }

        public async Task<ParkatronDetailsViewModel> GetAllDataFromGarage()
        {
           ParkatronDetailsViewModel _stats = new();
           _stats.NumberOfRegisteredUsers = await _db.User.CountAsync();
           _stats.RegisteredVehicleTypes = await GetVehicleTypeTuple();
           _stats.NumberOfRegisteredVehicles = await GetRegisteredVehicles();
           _stats.TotalWheels = await GetVehicleWheelCount();
            _stats.NumberOfParkedVehicles = await GetNumberOfParkedVehicle();
            _stats.EarnedTotals = await GetTotalEarnings();
            _stats.UsedParkingSlots = await GetNumberOfUsedParkingSlots();

            return _stats;
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

        private async Task<int> GetNumberOfParkedVehicle()
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
