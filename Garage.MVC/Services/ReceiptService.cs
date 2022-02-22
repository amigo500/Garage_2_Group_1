using Garage_2_Group_1.Models.ViewModels;

namespace Garage_2_Group_1.Services
{
    public class ReceiptService : IReceiptService
    {
        public int InitPrice { get; set; } = 50;
        public int HourlyRate { get; set; } = 70;

        private readonly GarageContext2 db;
        public ReceiptService(GarageContext2 db) => this.db = db;
        /// <summary>
        /// Creates a Database Entry for this Vehicles Receipt. 
        /// </summary>
        /// <returns>Boolean for Success</returns>
        public async Task<bool> CreateReceiptOnParkAsync(Vehicle vehicle)
        {
            var name = vehicle.User.FirstName + " " + vehicle.User.LastName;
            var receipt = new Receipt(vehicle.RegNr, name);
            db.Receipt.Add(receipt);
            await db.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Updates the Vehicles Receipt at Checkout.
        /// </summary>
        /// <returns>returns the Receipt Object Async.</returns>
        public async Task<bool> SetCheckoutReceiptAsync(ReceiptViewModel viewModel)
        {
            var receipt = await db.Receipt.FirstOrDefaultAsync(r => r.VehicleRegNr == viewModel.VehicleRegNr);

            if (receipt == null)
            {
                return false;
            }

            receipt.CheckOutTime = viewModel.CheckOutTime;
            receipt.Price = viewModel.Price;
            receipt.ParkingDuration = viewModel.ParkingDuration;

            db.Update(receipt);
            await db.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Get the total price for the parking duration at checkout
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns>The price paid at checkout</returns>
        public int GetPriceTotal(Vehicle vehicle, double totalHours)
        {
            var totalPrice = InitPrice + (HourlyRate * totalHours);

            if (vehicle.VehicleType.Size == 2)
            {
                totalPrice = (InitPrice * 1.3) + (HourlyRate * 1.4 * totalHours);
            }
            else if (vehicle.VehicleType.Size == 3)
            {
                totalPrice = (InitPrice * 1.6) + (HourlyRate * 1.5 * totalHours);
            }

            return (int) totalPrice;
        }
    }


}
