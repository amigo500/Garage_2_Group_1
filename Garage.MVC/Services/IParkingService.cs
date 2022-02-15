namespace Garage_2_Group_1.Services
{
    public interface IParkingService
    {
        bool[] EmptyParkingSlots { get; }
        int EmptyParkingSlotsCount { get; set; }
        int Capacity { get; }
        int FindMaxSize(string currentSlots = "");
        (bool result, int firstSlot) HasParkingSlots(int size, string currentSlots = "");
        string? GetParkingSlots(int size);
        void FreeParkingSlots(string slots);
    }
}