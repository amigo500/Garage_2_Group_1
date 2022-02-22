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
        [Key]
        public int Id { get; set; } 
        public DateTime ArrivalTime { get; private set; } = DateTime.Now;
        public DateTime? CheckOutTime { get; set; }
        public int Price { get; set; }
        public string UserFullName { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh} Hours {0:mm} Minutes")]
        public TimeSpan ParkingDuration { get; set; }
        
        public string VehicleRegNr { get; set; }
        public Vehicle Vehicle { get; set; }
        
        private Receipt() { }

        public Receipt(string vehicleRegNr, string userFullName)
        {
            VehicleRegNr = vehicleRegNr;
            UserFullName = userFullName;
        }

    }
}
