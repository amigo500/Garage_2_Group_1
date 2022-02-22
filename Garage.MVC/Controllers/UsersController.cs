#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage.Entities;
using Bogus;
using AutoMapper;
using Garage_2_Group_1.Models.UserViewModels;
using System.Text.RegularExpressions;
using Garage_2_Group_1.Models.ViewModels;

namespace Garage_2_Group_1.Controllers
{
    public class UsersController : Controller
    {
        private readonly Faker faker;
        private readonly GarageContext2 db;
        private readonly IMapper mapper;
        private readonly IParkingService _ps;
        private readonly IReceiptService _rs;

        public UsersController(GarageContext2 context, IMapper mapper, IParkingService ps, IReceiptService rs)
        {
            this.mapper = mapper;
            db = context;
            faker = new Faker("en");
            _ps = ps;
            _rs = rs;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var model = mapper.ProjectTo<UserDetailsViewModel>(db.User);

            return View(await model.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
           
            var user = await mapper.ProjectTo<UserDetailsViewModel>(db.User)
                .FirstOrDefaultAsync(m => m.SSN == id);

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var user = new UserCreateViewModel();

            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel viewModel)
        {
            var user = mapper.Map<User>(viewModel);
            user.Avatar = faker.Internet.Avatar();

            db.Add(user);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Checkout
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(ReceiptViewModel viewModel)
        {
            var vehicle = await db.Vehicle
                .Include(v => v.ParkingSlots)
                .FirstAsync(v => v.RegNr == viewModel.VehicleRegNr);

            var parkingSlots = vehicle.ParkingSlots.ToList();

            // Free parking slots
            foreach (var slot in parkingSlots)
            {
                await _ps.FreeParkingSlotAsync(slot);
            }

            // Update receipt
            await _rs.SetCheckoutReceiptAsync(viewModel);

            TempData["checkout"] = true;
            TempData["regNr"] = viewModel.VehicleRegNr;

            var ssn = vehicle.UserSSN;

            return RedirectToAction(nameof(Details),new { @id = vehicle.UserSSN});
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await mapper.ProjectTo<UserEditViewModel>(db.User)
                                   .FirstOrDefaultAsync(u => u.SSN == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, UserEditViewModel viewModel)
        {
            if (id != viewModel.SSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await db.User.FirstOrDefaultAsync(u => u.SSN == id);

                    mapper.Map(viewModel, user);
                    db.Update(user);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(viewModel.SSN))
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
            return View(viewModel);
        }

        private bool UserExists(long id)
        {
            return db.User.Any(e => e.SSN == id);
        }

        public IActionResult CheckSSN(long ssn)
        {
            var s = ssn.ToString();
            var rx = new Regex("^(19|20)?[0-9]{2}[- ]?((0[0-9])|(10|11|12))[- ]?(([0-2][0-9])|(3[0-1])|(([7-8][0-9])|(6[1-9])|(9[0-1])))[- ]?[0-9]{4}$");

            if (!rx.IsMatch(s))
                return Json("Invalid Social Security number");

            var ssnYear = Int32.Parse(s.Substring(0, 4));
            var ssnMonth = Int32.Parse(s.Substring(4, 2));
            var ssnDay = Int32.Parse(s.Substring(6, 2));

            var birthday = new DateTime(ssnYear, ssnMonth, ssnDay);

            if (birthday.CompareTo(DateTime.Now) > 0)
            {
                return Json("Sorry, no time travelers allowed (not born yet)");
            }

            return Json(true);
        }
        
        public IActionResult CheckLastName(string firstname, string lastname)
        {
            if (firstname == lastname)
            {
                return Json("Invalid last name (has to different from your first name)");
            }

            return Json(true);
        }


    }
}
