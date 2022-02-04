using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Utils
{
    public static class Receipt
    {
        public static string PrintableReceipt(Vehicle vehicle)
        {
            var checkoutTime = DateTime.Now;
            var time = checkoutTime - vehicle.ArrivalTime;
            var totalParkedTime = "";

            if (time.TotalHours < 1)
                totalParkedTime = $"{time.Minutes} minutes";
            else if (time.TotalDays < 1)
                totalParkedTime = $"{time.Hours} hours, {time.Minutes} minutes";
            else
                totalParkedTime = $"{time.Days} days, {time.Hours} hours, {time.Minutes} minutes";
            var price = 50 + (int)time.TotalHours * 15;


            string receiptInfo = $"{vehicle.RegNr}^{vehicle.ArrivalTime}^{checkoutTime}^{totalParkedTime}^{price}";

            return receiptInfo;
        }

} }
