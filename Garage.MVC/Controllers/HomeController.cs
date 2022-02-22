using AutoMapper;
using Garage_2_Group_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garage_2_Group_1.Controllers
{
    public class HomeController : Controller
    {
        private IMapper mapper;
        private GarageContext2 _db;

        public HomeController(GarageContext2 context, IMapper mapper)
        {
            this.mapper = mapper;
            _db = context;
        }



        public async Task<IActionResult> Index()
        {
            var model = GetAllDataFromGarage(_db);
            return View(await model);
        }

       
    }
}
