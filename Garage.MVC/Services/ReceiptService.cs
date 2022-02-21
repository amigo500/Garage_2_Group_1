namespace Garage_2_Group_1.Services
{
    public class ReceiptService : IReceiptService
    {
        public int InitPrice { get; set; } = 50;
        public int HourlyRate { get; set; } = 70;

        private readonly GarageContext2 db;
        private Receipt _receipt;
        private Vehicle _vehicle;
        public ReceiptService(GarageContext2 db) => this.db = db;

        public void CreateReceiptOnPark(Vehicle vehicle)
        {
            _vehicle = vehicle;
            var parkingSlots = _vehicle.ParkingSlots;
            var regNr = _vehicle.RegNr;
            var name = _vehicle.User.FirstName + " " + _vehicle.User.LastName;

            _receipt = new Receipt(_vehicle, parkingSlots, regNr, name);
            db.Add(_receipt);
            db.SaveChanges();
        }

        public Receipt CheckoutReceipt()
        {
            GetPriceTotal();



            return _receipt;
        }

        private void GetPriceTotal()
        {
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

            _receipt.Price = finalPrice;
            db.Update(_receipt);
            db.SaveChanges();
        }
    }


}
