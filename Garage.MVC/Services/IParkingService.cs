using Garage.Entities;

namespace Garage_2_Group_1.Services
{
    public interface IParkingService
    {
        string?[] EmptyParkingSlots { get; }
        int EmptyParkingSlotsCount { get; }
        int Capacity { get; }
        bool IsEmpty(int index);
        bool IsParked(string regNr);
        int FindMaxSize();
        int FindMaxSize(ICollection<ParkingSlot> currentSlots);
        (bool result, int firstSlot) HasParkingSlotsForSize(int size);
        (bool result, int firstSlot) HasParkingSlotsForSize(int size, ICollection<ParkingSlot> currentSlots);
        ICollection<ParkingSlot>? GetParkingSlots(int size, string regNr);
        Task FreeParkingSlotAsync(ParkingSlot slot);
        Task ParkInSlotAsync(ParkingSlot slot);
    }
}