using Garage.Entities;

namespace Garage_2_Group_1.Services
{
    public interface IParkingService
    {
        string?[] EmptyParkingSlots { get; }
        int EmptyParkingSlotsCount { get; set; }
        int Capacity { get; }
        int FindMaxSize(ICollection<ParkingSlot>? currentSlots = null);
        (bool result, int firstSlot) HasParkingSlots(int size, ICollection<ParkingSlot>? currentSlots = null);
        ICollection<ParkingSlot>? GetParkingSlots(int size, string regNr);
        Task FreeParkingSlotsAsync(List<ParkingSlot> parkingSlots);
    }
}