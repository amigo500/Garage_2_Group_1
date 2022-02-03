using Garage_2_Group_1.Data;
using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Services
{
    public class ParkingService : IParkingService
    {
        public bool[] EmptyParkingSlots { get; }
        public int EmptyParkingSlotsCount { get; set; }
        public int Capacity { get; }

        private readonly GarageConfiguration _config;
        private readonly Garage_2_Group_1Context _db;

        public ParkingService(Garage_2_Group_1Context context, GarageConfiguration gc)
        {
            _db = context;
            _config = gc;

            EmptyParkingSlots = Enumerable.Repeat(true, _config.Capacity).ToArray();
            Capacity = _config.Capacity;
            EmptyParkingSlotsCount = Capacity;

            _db.Vehicle.Select(v => v.ParkingSlots).ToList().ForEach(s => ParkInSlots(s));
        }

        public void FreeParkingSlots(string slots)
        {
            var parkedSlots = ParseSlotString(slots);
            foreach (var slotIndex in parkedSlots)
            {
                EmptyParkingSlots[slotIndex] = true;
                EmptyParkingSlotsCount++;
            }
        }

        public string? GetParkingSlots(int size)
        {
            var parkingSlots = HasParkingSlots(size);
            
            if (!parkingSlots.result) return null;
            else
            {
                var slots = "";               
                for (int i = 0; i < size; i++) {
                    slots += (parkingSlots.firstSlot + i) + " ";
                }
                slots = slots.Trim();
                ParkInSlots(slots);
                return slots;
            }
        }

        public (bool result, int firstSlot) HasParkingSlots(int size, string currentSlots = "")
        {
            var parkingSlots = (result: false, firstSlot: -1);

            // If the vehicle already has one or more parking slots assigned
            if (!String.IsNullOrEmpty(currentSlots))
            {
                var slots = ParseSlotString(currentSlots);
                var firstSlot = slots.First();
                var lastSlot = slots.Last();

                // If we're trying to edit a vehicle to a smaller size
                if (slots.Count >= size)
                {
                    parkingSlots.result = true;
                    parkingSlots.firstSlot = slots.First();
                }

                // See if the neighbour slots after are unoccupied
                else if (!parkingSlots.result && firstSlot + size <= EmptyParkingSlots.Length)
                {
                    var enoughSlots = true;
                    for (int i = 1; i < size && (lastSlot + i) < EmptyParkingSlots.Length; i++)
                    {
                        if (!EmptyParkingSlots[lastSlot + i])
                        {
                            enoughSlots = false;
                        }
                    }
                    if (enoughSlots)
                    {
                        parkingSlots.result = true;
                        parkingSlots.firstSlot = slots.First();
                    }
                }

                // See if the neighbour slots before are unoccupied
                else if (!parkingSlots.result && firstSlot - size >= 0)
                {
                    var enoughSlots = true;
                    for (int i = 1; i < size && (firstSlot - i) >= 0; i++)
                    {
                        if (!EmptyParkingSlots[firstSlot - i])
                        {
                            enoughSlots = false;
                        }
                    }
                    if (enoughSlots)
                    {
                        parkingSlots.result = true;
                        parkingSlots.firstSlot = slots.First() - size;
                    }
                }

            }

            if(!parkingSlots.result)
            {
                for (int i = 0; i < EmptyParkingSlots.Length; i++)
                {
                    // found an empty slot
                    if (EmptyParkingSlots[i])
                    {
                        var enoughSlots = true;
                        // if we need more than 1 slot

                        if (i + size > EmptyParkingSlots.Length) enoughSlots = false;

                        for (int j = 1; j < size && i + j < EmptyParkingSlots.Length; j++)
                        {
                            if (!EmptyParkingSlots[i + j])
                            {
                                enoughSlots = false;
                                break;
                            }
                        }
                        if (enoughSlots)
                        {
                            parkingSlots.result = true;
                            parkingSlots.firstSlot = i;
                            break;
                        }
                        else
                        {
                            i += size;
                        }
                    }
                }
            }
            return parkingSlots;
        }

        public int FindMaxSize(string currentSlots = "")
        {
            int maxSize = 0;
            for (int i = 3; i > 0; i--)
            {
                var check = HasParkingSlots(i, currentSlots);
                if (check.result)
                {
                    maxSize = i;
                    break;
                }
            }

            return maxSize;
        }

        private List<int> ParseSlotString(string slots) => slots.Split(' ').Select(int.Parse).ToList();

        private void ParkInSlots(string slots)
        {
            var parkedSlots = ParseSlotString(slots);
            foreach (var slotIndex in parkedSlots)
            {
                EmptyParkingSlots[slotIndex] = false;
                EmptyParkingSlotsCount--;
            }
        }

        private int GetVehicleSize(VehicleType? type)
        {
            if (type == null) return 0;

            int size = 0;

            switch (type)
            {
                case VehicleType.Bus:
                    size = 2;
                    break;
                case VehicleType.Boat:
                    size = 3;
                    break;
                case VehicleType.Airplane:
                    size = 3;
                    break;
                case VehicleType.Car:
                    size = 1;
                    break;
                case VehicleType.Motorcycle:
                    size = 1;
                    break;
                default:
                    size = 1;
                    break;

            }
            return size;
        }
    }
}
