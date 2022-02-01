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

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var model = new VehicleIndexViewModel()
            {
                Vehicles = await _context.Vehicle.ToListAsync(),
                Types = await GetTypesAsync()
            };

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
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,Type,ArrivalTime,Color,Make,Model,WheelCount")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CheckRegNr(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if(!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.RegNr == regnr);

            if (dbResult != null)
                return Json("The registration number has to be unique (already parked)");

            return Json(true);
        }
    }
}
