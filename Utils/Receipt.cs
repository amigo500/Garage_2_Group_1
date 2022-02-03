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


            string printReceipt = $" <div id = \"receipt\" >< h4 > Receipt </ h4 >< hr />< dl class=\"row\">"
                + $"<dt class = \"col-sm-2\">Regristration Number: </dt>"
                + $"<dd class = \"col-sm-10\">{vehicle.RegNr}</dd>"
                + $"<dt class = \"col-sm-2\">Arrival Time: </dt>" 
                + $"<dd class = \"col-sm-10\">{vehicle.ArrivalTime}</dd>"
                + $"<dt class = \"col-sm-2\">Time of Checkout: </dt>"
                + $"<dd class = \"col - sm - 10\">{checkoutTime}</dd>"
                + $"<dt class = \"col-sm-2\">Total parked time:</dt>"
                + $"<dd class = \"col-sm-10\">{totalParkedTime}</dd>"
                + $"<dt class = \"col-sm-2\">Price: </dt>"
                + $"<dd class = \"col-sm-10\">{price}</dd></dl></div> ";

            return printReceipt;
        }

} }
