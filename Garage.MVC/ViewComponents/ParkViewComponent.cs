using Garage_2_Group_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garage_2_Group_1.ViewComponents
{
    public class ParkViewComponent : ViewComponent
    {
        private readonly IParkingService _ps;
        private readonly GarageContext2 _context;

        public ParkViewComponent(IParkingService service, GarageContext2 context)
        {
            _ps = service;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string regNr)
        {
            var parking = _ps.EmptyParkingSlots;
            var query = await _context.Vehicle
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(v => v.RegNr == regNr);

            if (query == null) 
                throw new Exception($"No vehicle found with that registration number ({regNr})");

            var viewModel = new ParkViewModel
            {
                RegNr = regNr,
                ParkingSlots = parking,
                VehicleType = query.VehicleType
            };

            return View(viewModel);
        }
    }
}
