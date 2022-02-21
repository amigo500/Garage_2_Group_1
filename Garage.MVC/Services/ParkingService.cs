using Garage.Data;
using Garage.Entities;
using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Services
{
    public class ParkingService : IParkingService
    {
        public string[] EmptyParkingSlots { get; }
        public int EmptyParkingSlotsCount { get; private set; }
        public int Capacity { get; }

        private readonly GarageContext2 _db;

        public ParkingService(GarageContext2 context)
        {
            _db = context;

            var parkingSlots = _db.ParkingSlot.ToList();

            Capacity = parkingSlots.Count;
            EmptyParkingSlotsCount = Capacity;

            EmptyParkingSlots = Enumerable.Repeat("", Capacity + 1).ToArray();

            parkingSlots.ForEach(s =>
            {
                if (s.VehicleRegNr != null)
                {
                    EmptyParkingSlots[s.Id] = s.VehicleRegNr!;
                    EmptyParkingSlotsCount--;
                }
            });
        }

        public ICollection<ParkingSlot>? GetParkingSlots(int size, string regNr)
        {
            var parkingSlots = HasParkingSlotsForSize(size);
            
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

        /// <summary>
        /// Check if the garage has slots for a vechicle.
        /// </summary>
        /// <param name="size">The size of the vehicle.</param>
        /// <returns></returns>
        public (bool result, int firstSlot) HasParkingSlotsForSize(int size)
        {
            var parkingSlots = (result: false, firstSlot: -1);

            for (int i = 1; i < Capacity; i++)
            {
                if (VehicleFitsAt(i, size))
                {
                    parkingSlots.result = true;
                    parkingSlots.firstSlot = i;
                    break;
                }
            }

            return parkingSlots;
        }

        /// <summary>
        /// Check if the garage has slots for a vechicle.
        /// </summary>
        /// <param name="size">The size of the vehicle.</param>
        /// <param name="currentParking">Adds additonal slots as avialable for parking,
        ///     useful when editing a vehicle type to another size.</param>
        /// <returns></returns>
        public (bool result, int firstSlot) HasParkingSlotsForSize(int size, ICollection<ParkingSlot> currentParking)
        {
            var parkingSlots = (result: false, firstSlot: -1);
            var firstSlot = currentParking.First().Id;
            var lastSlot = currentParking.Last().Id;

            // Check if the current parking can be used
            for (int i = lastSlot - size; i <= firstSlot + size; i++)
            {
                if (VehicleFitsAt(i, size, currentParking))
                {
                    parkingSlots.result = true;
                    parkingSlots.firstSlot = i;
                    break;
                }
            }

            // Otherwise check the rest of the garage 
            if(!parkingSlots.result)
            {
                parkingSlots = HasParkingSlotsForSize(size);
            }
            return parkingSlots;
        }

        public int FindMaxSize()
        {
            int maxSize = 0;
            for (int i = 3; i > 0; i--)
            {
                var (result, _) = HasParkingSlotsForSize(i);
                if (result)
                {
                    maxSize = i;
                    break;
                }
            }

            return maxSize;
        }
        public int FindMaxSize(ICollection<ParkingSlot> currentParking)
        {
            int maxSize = 0;
            for (int i = 3; i > 0; i--)
            {
                var check = HasParkingSlotsForSize(i, currentParking);
                if (check.result)
                {
                    maxSize = i;
                    break;
                }
            }

            return maxSize;
        }

        public bool IsEmpty(int index) => EmptyParkingSlots[index] == "";

        public async Task FreeParkingSlotAsync(ParkingSlot slot)
        {
            slot.VehicleRegNr = null;
            _db.ParkingSlot.Update(slot);
            await _db.SaveChangesAsync();

            EmptyParkingSlots[slot.Id] = "";
            EmptyParkingSlotsCount++;
        }

        public async Task ParkInSlotAsync(ParkingSlot slot)
        {
            _db.ChangeTracker.Clear();
            _db.ParkingSlot.Update(slot);
            await _db.SaveChangesAsync();

            EmptyParkingSlots[slot.Id] = slot.VehicleRegNr!;
            EmptyParkingSlotsCount--;
        }

        private bool VehicleFitsAt(int index, int size)
        {
            if (index < 1 || index + size >= Capacity) return false;

            var fits = true;
            for (int i = 0; i < size; i++)
            {
                if (!IsEmpty(index + i))
                {
                    fits = false;
                    break;
                }
            }
            return fits;
        }

        private bool VehicleFitsAt(int index, int size, ICollection<ParkingSlot> currentParking)
        {
            if (index - size < 1 || index + size >= Capacity) return false;

            var fits = true;
            for (int i = 0; i < size; i++)
            {
                if (!IsEmpty(index + i) && !currentParking.Any(p => p.Id == index + i))
                {
                    fits = false;
                    break;
                }
            }
            return fits;
        }

        public bool IsParked(string regNr)
        {
            return EmptyParkingSlots.Contains(regNr);
        }
    }
}
