using Garage.Data;
using Garage.Entities;
using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Services
{
    public class ParkingService : IParkingService
    {
        public string[] EmptyParkingSlots { get; }
        public int EmptyParkingSlotsCount { get; set; }
        public int Capacity { get; }

        private readonly GarageConfiguration _config;
        private readonly GarageContext _db;

        public ParkingService(GarageContext context, GarageConfiguration gc)
        {
            _db = context;
            _config = gc;

            EmptyParkingSlots = Enumerable.Repeat("", _config.Capacity).ToArray();
            Capacity = _config.Capacity;
            EmptyParkingSlotsCount = Capacity;

            _db.Vehicle.Select(v => v.ParkingSlots).ToList()
                .ForEach(slots => slots.ToList()
                .ForEach(s => 
                    {
                        EmptyParkingSlots[s.Id] = s.VehicleRegNr!;
                        EmptyParkingSlotsCount--;
                    })
                );
        }

        public async Task FreeParkingSlotsAsync(List<ParkingSlot> parkingSlots)
        {
            var tasks = new List<Task>();
            parkingSlots.ForEach(slot => tasks.Add(FreeParkingSlotAsync(slot)));
            await Task.WhenAll(tasks);
        }

        public async Task ParkInSlotsAsync(List<ParkingSlot> parkingSlots)
        {
            var tasks = new List<Task>();
            parkingSlots.ForEach(slot => tasks.Add(ParkInSlotAsync(slot)));
            await Task.WhenAll(tasks);
        }

        public ICollection<ParkingSlot>? GetParkingSlots(int size, string regNr)
        {
            var parkingSlots = HasParkingSlots(size);
            
            if (!parkingSlots.result) return null;
            else
            {
                var slots = new List<ParkingSlot>();
                for (int i = 0; i < size; i++)
                {
                    slots.Add(new ParkingSlot(parkingSlots.firstSlot + i, regNr));
                }
                return slots;
            }
        }

        public (bool result, int firstSlot) HasParkingSlots(int size, ICollection<ParkingSlot>? currentSlots = null)
        {
            var parkingSlots = (result: false, firstSlot: -1);

            // If the vehicle already has one or more parking slots assigned
            if (currentSlots != null)
            {
                var firstSlot = currentSlots.First().Id;
                var lastSlot = currentSlots.Last().Id;

                // Always possible to edit a vehicle to a smaller or same size
                if (currentSlots.Count >= size)
                {
                    parkingSlots.result = true;
                    parkingSlots.firstSlot = firstSlot;
                }

                // See if the neighbour slots after are unoccupied
                if (!parkingSlots.result && firstSlot + size - 1 < EmptyParkingSlots.Length)
                {
                    var enoughSlots = true;
                    for (int i = 1; i <= (size - currentSlots.Count) && (lastSlot + i) < EmptyParkingSlots.Length; i++)
                    {
                        if (!IsEmpty(lastSlot + i))
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
                if (!parkingSlots.result && firstSlot - (size - currentSlots.Count) >= 0)
                {
                    var enoughSlots = true;
                    for (int i = 1; i <= (size - currentSlots.Count) && (firstSlot - i) >= 0; i++)
                    {
                        if (!IsEmpty(firstSlot - i))
                        {
                            enoughSlots = false;
                            break;
                        }
                    }
                    if (enoughSlots)
                    {
                        parkingSlots.result = true;
                        parkingSlots.firstSlot = firstSlot - (size - currentSlots.Count);
                    }
                }

            }

            if(!parkingSlots.result)
            {
                for (int i = 0; i < Capacity; i++)
                {
                    // found an empty slot
                    if (IsEmpty(i))
                    {
                        var enoughSlots = true;

                        if (i + size > Capacity) enoughSlots = false;

                        // if we need more than 1 slot check if the trailing slots are empty
                        for (int j = 1; j < size && i + j < Capacity; j++)
                        {
                            if (!IsEmpty(i + j))
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

        public int FindMaxSize(ICollection<ParkingSlot>? currentSlots = null)
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

        private bool IsEmpty(int index) => EmptyParkingSlots[index] == "";

        private async Task FreeParkingSlotAsync(ParkingSlot slot)
        {
            slot.VehicleRegNr = null;
            _db.ParkingSlot.Update(slot);
            await _db.SaveChangesAsync();

            EmptyParkingSlots[slot.Id] = "";
            EmptyParkingSlotsCount++;
        }

        private async Task ParkInSlotAsync(ParkingSlot slot)
        {
            _db.ParkingSlot.Update(slot);
            await _db.SaveChangesAsync();

            EmptyParkingSlots[slot.Id] = slot.VehicleRegNr!;
            EmptyParkingSlotsCount--;
        }
    }
}
