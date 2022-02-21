using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage_2_Group_1.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int Price { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleRegNr { get; set; }
        public string UserFullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh} Hours {0:mm} Minutes")]
        public TimeSpan ParkingDuration { get; set; }
    }
}
