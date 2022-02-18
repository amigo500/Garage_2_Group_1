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

namespace Garage_2_Group_1.Controllers
{
    public class UsersController : Controller
    {
        private readonly Faker faker;
        private readonly GarageContext2 db;
        private readonly IMapper mapper;

        public UsersController(GarageContext2 context, IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
            faker = new Faker("en");
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
    }
}
