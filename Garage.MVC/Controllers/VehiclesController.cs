﻿#nullable disable
using AutoMapper;
using Garage.Entities;
using Garage_2_Group_1.Models.VehicleVeiwModels;

using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageContext2 _db;
        private readonly IMapper _mapper;
        private readonly IParkingService _ps;

        public VehiclesController(GarageContext2 context, IMapper mapper, IParkingService ps)
        {
            _db = context;
            _mapper = mapper;
            _ps = ps;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var model = _mapper.ProjectTo<VehicleIndexViewModel>(_db.Vehicle);
            return View(await model.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _mapper.ProjectTo<VehicleIndexViewModel>(_db.Vehicle)
                                       .FirstOrDefaultAsync(v => v.RegNr == id);

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
                _db.Add(vehicle);
                await _db.SaveChangesAsync();

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
                var vehicle = await _db.Vehicle
                    .Include(v => v.VehicleType)
                    .FirstOrDefaultAsync(m => m.RegNr == viewModel.RegNr);

                // Vehicle is already parked (occurs on page refresh after successful parking)
                if (vehicle.ParkingSlots.Count > 0)  
                    return View(viewModel); 

                var parkingSlots = _ps.GetParkingSlots(vehicle.VehicleType.Size, viewModel.RegNr);
                
                if (parkingSlots == null)
                {
                    viewModel = new VehicleParkViewModel { ParkedSuccesfully = false };
                }

                else
                {
                    foreach (ParkingSlot slot in parkingSlots)
                    {
                        slot.VehicleRegNr = viewModel.RegNr;
                        await _ps.ParkInSlotAsync(slot);
                    }
                    ModelState.Clear();
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

            var vehicle = await _mapper.ProjectTo<VehicleEditViewModel>(_db.Vehicle)
                                       .FirstOrDefaultAsync(r => r.RegNr == id);
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
        public async Task<IActionResult> Edit(string regNr, VehicleEditViewModel viewModel)
        {
            if (regNr != viewModel.RegNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = await _db.Vehicle.FindAsync(regNr);
                    vehicle.RegNr = viewModel.RegNr;
                    vehicle.VehicleTypeID = (int)viewModel.VehicleTypeID;
                    vehicle.Color = (VehicleColor)viewModel.Color;
                    vehicle.Make = viewModel.Make;
                    vehicle.Model = viewModel.Model;
                    vehicle.WheelCount = viewModel.WheelCount;

                    _db.Update(vehicle);
                    await _db.SaveChangesAsync();
                    viewModel.EditedSuccesfully = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(viewModel.RegNr))
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

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _db.Vehicle
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
            var vehicle = await _db.Vehicle.FindAsync(id);
            _db.Vehicle.Remove(vehicle);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
            return _db.Vehicle.Any(e => e.RegNr == id);
        }

        public async Task<IActionResult> CheckRegNr(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = await _db.Vehicle.FirstOrDefaultAsync(m => m.RegNr == regnr);

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

        public async Task<IActionResult> Parkable(string regnr)
        {
            //check validation
            Validation val = new Validation();
            if (!val.RegIdValidation(regnr))
                return Json("Invalid registration number");

            //check database
            var dbResult = await _db.Vehicle.FirstOrDefaultAsync(m => m.RegNr == regnr);

            if (dbResult == null)
                return Json("Vehicle is not registered, register a new vehicle?");

            if (dbResult.ParkingSlots.Count > 0)
                return Json("Vehicle is already parked");

            return Json(true);
        }

        public async Task<JsonResult> ParkInSelected([FromBody] SelectedParkingSlots dto)
        {
            var parkingSlots = new List<ParkingSlot>();

            for (var i = 0; i < dto.selected.Length; i++)
            {
                var slot = await _db.ParkingSlot
                    .FirstOrDefaultAsync(p => p.Id == Int32.Parse(dto.selected[i]));

                if (slot == null) 
                    return Json($"Parking slot not found for id {dto.selected[i]}");

                slot.VehicleRegNr = dto.regnr;
                await _ps.ParkInSlotAsync(slot);
            }

            return Json(true);
        }
    }
}
