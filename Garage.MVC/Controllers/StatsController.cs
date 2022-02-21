#nullable disable
using AutoMapper;
using Garage_2_Group_1.Models.ViewModels;

using Garage_2_Group_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Controllers
{
    public class StatsController : Controller
    {
        private readonly GarageContext2 _context;
        private readonly IMapper _mapper;
        private readonly IParkingService _ps;

        public StatsController(GarageContext2 context, IMapper mapper, IParkingService ps)
        {
            _context = context;
            _mapper = mapper;
            _ps = ps;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicle.ToListAsync();

            var model = new ParkingStatsViewModel
            {
              //  VehicleTypesData = Enum.GetValues(typeof(VehicleType))
                //                       .Cast<VehicleType>()
                  //                     .ToDictionary(type => type.ToString(), type => vehicles
                                                      //                                  .Where(v => v.VehicleType == type)
                                                        //                                .Count()),

                WheelCount = vehicles
                                    
                                    .Select(v => v.WheelCount)
                                    .Sum(),


            };
            return View(model);

        }
    }
}
