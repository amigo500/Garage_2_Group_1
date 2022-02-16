#nullable disable

using Garage.Entities.Vehicles;
using Garage_2_Group_1.Models.ViewModels;
using Garage_2_Group_1.Services;
using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Garage_2_Group_1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageContext dB;
        private readonly IParkingService ps;

        public VehiclesController(GarageContext context, IParkingService parkingService)
        {
            dB = context;
            ps = parkingService;
        }

        public async Task<IActionResult> Index(string? receiptInfo)
        {
            if (!string.IsNullOrWhiteSpace(receiptInfo))
            {
                string[] split = receiptInfo.Split('^');

                TempData["RegId"] = split[0];
                TempData["ArrivalTime"] = split[1];
                TempData["CheckoutTime"] = split[2];
                TempData["ParkedTime"] = split[3];
                TempData["Price"] = split[4];

            }


            var model = new VehicleIndexViewModel()
            {
                Vehicles = await dB.Vehicle.ToListAsync(),
                Types = await GetTypesAsync()
            };

            if (receiptInfo != null) model.Checkout = true;

            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            return await dB.Vehicle
                           .Select(v => v.VehicleType)
                           .Distinct()
                           .Select(t => new SelectListItem
                           {
                               Text = t.ToString(),
                               Value = t.ToString()
                           })
                           .ToListAsync();
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await dB.Vehicle
                .FirstOrDefaultAsync(m => m.RegNr == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Park
        public IActionResult Park()
        {
            return View();
        }

        // POST: Vehicles/Park
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(VehicleParkViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    RegNr = viewModel.RegNr.ToUpper(),
                    Type = (VehicleType)viewModel.Type,
                    ArrivalTime = DateTime.Now,
                    Color = (VehicleColor)viewModel.Color,
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    WheelCount = viewModel.WheelCount
                };

                var size = vehicle.GetVehicleSize();
                var parkingSlots = ps.GetParkingSlots(size);
                vehicle.ParkingSlots = parkingSlots;
                
                if (parkingSlots == null)
                {
                    ModelState.AddModelError("Parking", $"No avaiable parking slot for size {size}");
                }

                if (ModelState.IsValid)
                {
                    dB.Add(vehicle);
                    await dB.SaveChangesAsync();

                    ModelState.Clear();
                    viewModel = new VehicleParkViewModel { ParkedSuccesfully = true };
                }
            }
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await dB.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleEditViewModel
            {
                Id = (int)id,
                RegNr = vehicle.RegNr,
                Type = vehicle.Type,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                WheelCount = vehicle.WheelCount,
                ParkingSlots = vehicle.ParkingSlots
            };

            return View(viewModel);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = await dB.Vehicle.FindAsync(id);
                    vehicle.RegNr = viewModel.RegNr;
                    vehicle.Type = viewModel.Type;
                    vehicle.Color = viewModel.Color;
                    vehicle.Make = viewModel.Make;
                    vehicle.Model = viewModel.Model;
                    vehicle.WheelCount = viewModel.WheelCount;

                    ps.FreeParkingSlots(vehicle.ParkingSlots);
                    vehicle.ParkingSlots = ps.GetParkingSlots(vehicle.GetVehicleSize());

                    dB.Update(vehicle);
                    await dB.SaveChangesAsync();
                    viewModel.EditedSuccesfully = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(viewModel);
        }

        // GET: Vehicles/Checkout/5
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await dB.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var checkoutTime = DateTime.Now;
            var time = checkoutTime - vehicle.ArrivalTime;
            var totalParkedTime = "";

            // A better looking total parked time string
            if (time.TotalHours < 1)
                totalParkedTime = $"{time.Minutes} minutes";
            else if (time.TotalDays < 1)
                totalParkedTime = $"{time.Hours} hours, {time.Minutes} minutes";
            else
                totalParkedTime = $"{time.Days} days, {time.Hours} hours, {time.Minutes} minutes";


            // 50 kr + 15 kr per hour
            var price = 50 + (int)time.TotalHours * 15;

            var viewModel = new VehicleCheckoutViewModel
            {
                Id = vehicle.Id,
                RegNr = vehicle.RegNr,
                ArrivalTime = vehicle.ArrivalTime,
                CheckoutTime = checkoutTime,
                TotalParkedTime = totalParkedTime,
                Price = price
            };

            return View(viewModel);
        }

        // POST: Vehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(int id)
        {
            var vehicle = await dB.Vehicle.FindAsync(id);
            ps.FreeParkingSlots(vehicle.ParkingSlots);
            var receiptInfo = Receipt.PrintableReceipt(vehicle);
            dB.Vehicle.Remove(vehicle);
            await dB.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { receiptInfo });
        }

        private bool VehicleExists(int id)
        {
            return dB.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CheckRegNr(string regnr, int? id)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = id == null ?
                    await dB.Vehicle
                    .FirstOrDefaultAsync(m => m.RegNr == regnr) :
                    await dB.Vehicle
                    .FirstOrDefaultAsync(m => m.RegNr == regnr && m.Id != id);

            if (dbResult != null)
                return Json("The registration number has to be unique (already parked)");

            return Json(true);
        }

        public IActionResult ValidateRegNr(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            return Json(true);
        }

        public async Task<IActionResult> Filter(VehicleIndexViewModel viewModel)
        {
            var vehicles = string.IsNullOrWhiteSpace(viewModel.RegNr) ?
                                    dB.Vehicle :
                                    dB.Vehicle.Where(m => m.RegNr.StartsWith(viewModel.RegNr));

            vehicles = viewModel.Type == null ?
                             vehicles :
                             vehicles.Where(v => v.Type == viewModel.Type);

            var model = new VehicleIndexViewModel
            {
                Vehicles = await vehicles.ToListAsync(),
                Types = await GetTypesAsync()
            };

            return View(nameof(Index), model);
        }

        public async Task<IActionResult> ParkingStats()
        {
            var vehicles = await dB.Vehicle.ToListAsync();
            double totalhours = 0;

            foreach (var v in vehicles)
            {
                double vehicleHours = (DateTime.Now - v.ArrivalTime).TotalHours;
                vehicleHours += (DateTime.Now - v.ArrivalTime).TotalDays / 24;
                totalhours += vehicleHours;
            }

            var model = new ParkingStatsViewModel
            {
                VehicleTypesData = Enum.GetValues(typeof(VehicleType))
                                       .Cast<VehicleType>()
                                       .ToDictionary(type => type.ToString(), type => vehicles
                                                                                        .Where(v => v.Type == type)
                                                                                        .Count()),

                WheelCount = vehicles
                                    .Where(v => v.ParkedSuccesfully = true)
                                    .Select(v => v.WheelCount)
                                    .Sum(),


                TotalRevenue = 50 + (int)totalhours * 15
            };
            


        
            return View(model);
        }
    

}
}
