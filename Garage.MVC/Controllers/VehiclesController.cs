#nullable disable
using AutoMapper;
using Garage_2_Group_1.Models.VehicleViewModels;
using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageContext2 _context;
        private readonly IMapper _mapper;
        private readonly IParkingService _ps;

        public VehiclesController(GarageContext2 context, IMapper mapper, IParkingService ps)
        {
            _context = context;
            _mapper = mapper;
            _ps = ps;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var garageContext2 = _context.Vehicle.Include(v => v.User).Include(v => v.VehicleType);
            return View(await garageContext2.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.User)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.RegNr == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(viewModel);
                _context.Add(vehicle);
                await _context.SaveChangesAsync();

                ModelState.Clear();
                viewModel = new VehicleCreateViewModel { CreatedSuccesfully = true };
            }
            return View(viewModel);
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
                var vehicle = await _context.Vehicle
                    .Include(v => v.VehicleType)
                    .FirstOrDefaultAsync(m => m.RegNr == viewModel.RegNr);

                var parkingSlots = _ps.GetParkingSlots(vehicle.VehicleType.Size, viewModel.RegNr);
                
                if (parkingSlots == null)
                {
                    viewModel = new VehicleParkViewModel { ParkedSuccesfully = false };
                }

                else
                {
                    await _ps.ParkInSlotsAsync(parkingSlots.ToList());
                    viewModel = new VehicleParkViewModel { ParkedSuccesfully = true };
                }
            }
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["UserSSN"] = new SelectList(_context.User, "SSN", "Avatar", vehicle.UserSSN);
            ViewData["VehicleTypeID"] = new SelectList(_context.Set<VehicleType>(), "Id", "Name", vehicle.VehicleTypeID);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RegNr,Color,Make,Model,WheelCount,UserSSN,VehicleTypeID")] Vehicle vehicle)
        {
            if (id != vehicle.RegNr)
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
                    if (!VehicleExists(vehicle.RegNr))
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
            ViewData["UserSSN"] = new SelectList(_context.User, "SSN", "Avatar", vehicle.UserSSN);
            ViewData["VehicleTypeID"] = new SelectList(_context.Set<VehicleType>(), "Id", "Name", vehicle.VehicleTypeID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.User)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.RegNr == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
            return _context.Vehicle.Any(e => e.RegNr == id);
        }

        public async Task<IActionResult> CheckRegNr(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = await _context.Vehicle.FirstOrDefaultAsync(m => m.RegNr == regnr);
                    
            if (dbResult != null)
                return Json("The registration number has to be unique (already parked)");

            return Json(true);
        }

        public async Task<IActionResult> Parkable(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = await _context.Vehicle.FirstOrDefaultAsync(m => m.RegNr == regnr);

            if (dbResult == null)
                return Json("Vehicle not registered, register?");

            return Json("Vehicle ready for parking!");
        }
    }
}
