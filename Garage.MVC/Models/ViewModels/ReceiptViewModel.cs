using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage_2_Group_1.Models.ViewModels
{
    public class ReceiptViewModel
    {
        [Display(Name = "Arrival")]
        [DisplayFormat(DataFormatString = @"{0:d} ({0:hh\:mm})")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Checkout")]
        [DisplayFormat(DataFormatString = @"{0:d} ({0:hh\:mm})")]
        public DateTime CheckOutTime { get; set; }
        public int Price { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [Display(Name = "Registration")]
        public string VehicleRegNr { get; set; }

        [Display(Name = "Driver")]
        public string UserFullName { get; set; }
        public string Duration { get; set; }
        public TimeSpan ParkingDuration { get; set; }
    }
}
