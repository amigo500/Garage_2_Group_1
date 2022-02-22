using Garage_2_Group_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garage_2_Group_1.ViewComponents
{
    public class CheckoutViewComponent : ViewComponent
    {
        private readonly IReceiptService _rs;
        private readonly GarageContext2 _context;

        public CheckoutViewComponent(IReceiptService rService, GarageContext2 context)
        {
            _rs = rService;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string regNr)
        {
            var receipt = await _context.Receipt
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(r => r.VehicleRegNr == regNr);

            var vehicle = await _context.Vehicle
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(r => r.RegNr == regNr);

            if (receipt == null || vehicle == null)
                throw new Exception($"Receipt or Vehicle couldn't be found with that registration number ({regNr})");

            var viewModel = new ReceiptViewModel
            {
                ArrivalTime = receipt.ArrivalTime,
                CheckOutTime = DateTime.Now,
                Make = receipt.Vehicle.Make,
                Model = receipt.Vehicle.Model,
                VehicleRegNr = regNr,
                UserFullName = receipt.UserFullName,
                ParkingDuration = DateTime.Now - receipt.ArrivalTime,
            };

            viewModel.Price = _rs.GetPriceTotal(vehicle, viewModel.ParkingDuration.TotalHours);

            // A better looking total parked duration string
            var span = viewModel.ParkingDuration;
            if (span.TotalHours < 1)
                viewModel.Duration = $"{span.Minutes} minutes";
            else if (span.TotalDays < 1)
                viewModel.Duration = $"{span.Hours} hours, {span.Minutes} minutes";
            else
                viewModel.Duration = $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes";

            return View(viewModel);
        }
    }
}
