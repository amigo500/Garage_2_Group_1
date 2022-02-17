using Garage.Entities;

namespace Garage_2_Group_1.Services
{
    public interface IParkingService
    {
        string?[] EmptyParkingSlots { get; }
        int EmptyParkingSlotsCount { get; }
        int Capacity { get; }
        bool IsEmpty(int index);
        int FindMaxSize(ICollection<ParkingSlot> currentSlots);
        (bool result, int firstSlot) HasParkingSlotsForSize(int size, ICollection<ParkingSlot> currentSlots);
        ICollection<ParkingSlot>? GetParkingSlots(int size, string regNr);
        Task FreeParkingSlotsAsync(List<ParkingSlot> parkingSlots);
    }
}