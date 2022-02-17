using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.VehicleViewModels
{
    public class VehicleParkViewModel
    {
        public long UserSSN { get; set; }

        public string? RegNr { get; set; }

        public bool? ParkedSuccesfully { get; set; }
    }
}
