#nullable disable
using Garage_2_Group_1.Data;
using Garage_2_Group_1.Models;
using Garage_2_Group_1.Models.ViewModels;
using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage_2_Group_1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_2_Group_1Context _context;

        public VehiclesController(Garage_2_Group_1Context context)
        {
            _context = context;
        }

       
    

        public async Task<IActionResult> Index(bool? checkout, string? print)
        {
            var model = new VehicleIndexViewModel()
            {
                Vehicles = await _context.Vehicle.ToListAsync(),
                Types = await GetTypesAsync()
            };

            if (checkout != null) model.Checkout = checkout;

            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            return await _context.Vehicle
                           .Select(v => v.Type)
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

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
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

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                
                ModelState.Clear();
                viewModel = new VehicleParkViewModel { ParkedSuccesfully = true };

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

            var vehicle = await _context.Vehicle.FindAsync(id);
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
                WheelCount = vehicle.WheelCount
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
                    var vehicle = await _context.Vehicle.FindAsync(id);
                    vehicle.RegNr = viewModel.RegNr;
                    vehicle.Type = viewModel.Type;
                    vehicle.Color = viewModel.Color;
                    vehicle.Make = viewModel.Make;
                    vehicle.Model = viewModel.Model;
                    vehicle.WheelCount = viewModel.WheelCount;

                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
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

            var vehicle = await _context.Vehicle
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
            else if(time.TotalDays < 1)
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
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {checkout = true});
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CheckRegNr(string regnr, int? id)
        {
            //check validation
            Validation val = new Validation();
            if(!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = id == null ?
                    await _context.Vehicle
                    .FirstOrDefaultAsync(m => m.RegNr == regnr) :
                    await _context.Vehicle
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
                                    _context.Vehicle :
                                    _context.Vehicle.Where(m => m.RegNr.StartsWith(viewModel.RegNr));

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
    }
}
