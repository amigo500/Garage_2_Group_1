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
        private readonly GarageContext _db;

        public ParkingService(GarageContext context, GarageConfiguration gc)
        {
            _db = context;
            _config = gc;

            Capacity = GetCapacity(_config.Capacity);
            EmptyParkingSlots = Enumerable.Repeat(true, Capacity).ToArray();
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

                // Always possible to edit a vehicle to a smaller or same size
                if (slots.Count >= size)
                {
                    parkingSlots.result = true;
                    parkingSlots.firstSlot = firstSlot;
                }

                // See if the neighbour slots after are unoccupied
                if (!parkingSlots.result && firstSlot + size - 1 < EmptyParkingSlots.Length)
                {
                    var enoughSlots = true;
                    for (int i = 1; i <= (size - slots.Count) && (lastSlot + i) < EmptyParkingSlots.Length; i++)
                    {
                        if (!EmptyParkingSlots[lastSlot + i])
                        {
                            enoughSlots = false;
                            break;
                        }
                    }
                    if (enoughSlots)
                    {
                        parkingSlots.result = true;
                        parkingSlots.firstSlot = firstSlot;
                    }
                }

                // See if the neighbour slots before are unoccupied
                if (!parkingSlots.result && firstSlot - (size - slots.Count) >= 0)
                {
                    var enoughSlots = true;
                    for (int i = 1; i <= (size - slots.Count) && (firstSlot - i) >= 0; i++)
                    {
                        if (!EmptyParkingSlots[firstSlot - i])
                        {
                            enoughSlots = false;
                            break;
                        }
                    }
                    if (enoughSlots)
                    {
                        parkingSlots.result = true;
                        parkingSlots.firstSlot = firstSlot - (size - slots.Count);
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

                        if (i + size > EmptyParkingSlots.Length) enoughSlots = false;

                        // if we need more than 1 slot check if the trailing slots are empty
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

        // The capacity has to be at least the size of the last parking slot of the seeded vehicles
        private int GetCapacity(int sizeFromSettings)
        {
            int capacity = sizeFromSettings;
            List<List<int>> slots = new();

            var slotLists = _db.Vehicle.Select(v => v.ParkingSlots).ToList();
            slotLists.ForEach(slotString => slots.Add(ParseSlotString(slotString)));
            capacity = Math.Max(capacity, slots.SelectMany(x => x).Max() + 1);

            return capacity;
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
    }
}
