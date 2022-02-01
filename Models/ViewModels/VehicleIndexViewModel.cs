using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleIndexViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public IEnumerable<SelectListItem> Types { get; set; } = new List<SelectListItem>();
        public string? RegNr { get; set; }
        public VehicleType? Type { get; set; }
        public DateTime ArrivalTime { get; }
    }
}
