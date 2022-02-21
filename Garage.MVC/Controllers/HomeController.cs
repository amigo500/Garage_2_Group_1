#nullable disable
using AutoMapper;
using Garage.Entities;
using Garage_2_Group_1.Models.VehicleVeiwModels;

using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly GarageContext2 _context;
        private readonly IMapper _mapper;
        private readonly IParkingService _ps;

        public HomeController(GarageContext2 context, IMapper mapper, IParkingService ps)
        {
            _context = context;
            _mapper = mapper;
            _ps = ps;
        }

        //Get Statistics
        // public async Task<IActionResult> Index()
        //{

        //    var vehicles = await _context.Vehicle.ToListAsync();

        //        var model = new ParkatronDetailsViewModel
        //        {
        //        RegisteredVehicleTypes = Enum.GetValues(typeof(VehicleType))
        //                                   .Cast<VehicleType>()
        //                                   .ToDictionary(type => type.ToString(), type => 
        //                                                                                    .Where(v => v.Type == type)
        //                                                                                    .Count()),

        //            WheelCount = vehicles
        //                                .Select(v => v.WheelCount)
        //                                .Sum(),


        //        };




        //       return View(model);
        //   }


    }


}
