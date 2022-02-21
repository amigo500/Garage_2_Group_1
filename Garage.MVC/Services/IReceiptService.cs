namespace Garage_2_Group_1.Services
{
    public interface IReceiptService
    {
        public int InitPrice { get; set; }
        public int HourlyRate { get; set; }




        void CreateReceiptOnPark(Vehicle vehicle);
        Receipt CheckoutReceipt();





    }
}
