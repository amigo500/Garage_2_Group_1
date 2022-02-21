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
        public bool CreateReceiptOnPark(Vehicle vehicle)
        {
            Receipt _receipt;
            Vehicle _vehicle;
            _vehicle = vehicle;
            var parkingSlots = _vehicle.ParkingSlots;
            var regNr = _vehicle.RegNr;
            var name = _vehicle.User.FirstName + " " + _vehicle.User.LastName;

            _receipt = new Receipt(regNr, name);
            db.Add(_receipt);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Updates the Vehicles Receipt at Checkout with information like Price, ParkingDuration and CheckoutTime.
        /// </summary>
        /// <returns>returns the Receipt Object Async.</returns>
        public async Task<Receipt?> GetCheckoutReceipt(string regNr)
        {
            var _receipt = await db.Receipt.FirstOrDefaultAsync(r => r.VehicleRegId == regNr);

            if (_receipt == null)
            {
                return _receipt;
            }

            var timeNow = DateTime.Now;
            var timeThen = _receipt.ArrivalTime;
            TimeSpan ts = timeNow - timeThen;

            _receipt.ParkingDuration = ts;
            _receipt.Price = GetPriceTotal(_receipt);

            db.Update(_receipt);
            await db.SaveChangesAsync();
            return _receipt;
        }
        private int GetPriceTotal(Receipt _receipt)
        {
            var _vehicle = _receipt.Vehicle;
            var finalPrice = 0;
            double totalHours = _receipt.ParkingDuration.TotalHours;
            int defaultPriceTotal = InitPrice + (int)totalHours * HourlyRate;


            if (_vehicle.VehicleType.Size == 2)
            {
                var size2PriceTotal = 0;
                var initSize2 = (double)InitPrice * 1.3;
                var rateSize2 = _receipt.ParkingDuration.TotalHours * 1.4;
                size2PriceTotal = (int)initSize2 + (int)rateSize2 * HourlyRate;

                finalPrice = size2PriceTotal;
            }
            else if (_vehicle.VehicleType.Size == 3)
            {
                var size3PriceTotal = 0;
                var initSize3 = (double)InitPrice * 1.6;
                var rateSize3 = _receipt.ParkingDuration.TotalHours * 1.5;
                size3PriceTotal = (int)initSize3 + (int)rateSize3 * HourlyRate;

                finalPrice = size3PriceTotal;
            }
            else
            {
                finalPrice = defaultPriceTotal;
            }

            return finalPrice;
        }
    }


}
