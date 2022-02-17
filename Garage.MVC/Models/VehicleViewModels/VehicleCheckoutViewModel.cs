using System.ComponentModel.DataAnnotations;

namespace Garage_2_Group_1.Models.VehicleVeiwModels
{
    public class VehicleCheckoutViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration")]
        public string? RegNr { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Checkout Time")]
        public DateTime CheckoutTime { get; set; }

        [Display(Name = "Duration")]
        public string? TotalParkedTime { get; set; }
        public decimal Price { get; set; }
    }
}
