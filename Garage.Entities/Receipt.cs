using Garage.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Garage.Entities
{

    public class Receipt
    {
        public Receipt(string vehicleRegId, string userFullName)
        {
            VehicleRegId = vehicleRegId;
            UserFullName = userFullName;
        }

        [Key]
        public int Id { get; set; } 
        public DateTime ArrivalTime { get; } = DateTime.Now;
        public DateTime? CheckOutTime { get; set; }
        public int Price { get; set; }
        public Vehicle Vehicle { get; set; }
        public string VehicleRegId { get; set; }
        public string UserFullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh} Hours {0:mm} Minutes")]
        public TimeSpan ParkingDuration { get; set; }




    }
}
