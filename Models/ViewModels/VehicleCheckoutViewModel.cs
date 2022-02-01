namespace Garage_2_Group_1.Models.ViewModels
{
    public class VehicleCheckoutViewModel
    {
        public int Id { get; set; }
        public string? RegNr { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public string? TotalParkedTime { get; set; }
        public decimal Price { get; set; }
    }
}
