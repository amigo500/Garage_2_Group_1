namespace Garage_2_Group_1.Services
{
    public interface IReceiptService
    {
        public int InitPrice { get; set; }
        public int HourlyRate { get; set; }




        bool CreateReceiptOnPark(Vehicle vehicle);
        Task<Receipt?> GetCheckoutReceipt(string regNr);
        int GetPriceTotal(Receipt _receipt);





    }
}
