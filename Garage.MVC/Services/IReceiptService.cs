using Garage_2_Group_1.Models.ViewModels;

namespace Garage_2_Group_1.Services
{
    public interface IReceiptService
    {
        public int InitPrice { get; set; }
        public int HourlyRate { get; set; }
        Task<bool> CreateReceiptOnParkAsync(Vehicle vehicle);
        Task<bool> SetCheckoutReceiptAsync(ReceiptViewModel viewModel);
        int GetPriceTotal(Vehicle vehicle, double totalHours);

    }
}
