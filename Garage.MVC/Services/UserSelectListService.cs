using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Services
{
    public class UserSelectListService : IUserSelectListService
    {
        private readonly GarageContext2 _db;

        public UserSelectListService(GarageContext2 context)
        {
            _db = context;
        }

        public async Task<List<SelectListItem>> GetNameSelectListAsync()
        {
            var userList = new List<SelectListItem>();
            var users = await _db.User.OrderBy(u => u.FirstName).ToListAsync();

            users.ForEach(user => userList.Add(
                new SelectListItem { Text = $"{user.FirstName} {user.LastName}", Value = user.SSN.ToString() }
            ));

            return userList;
        }

        public async Task<List<SelectListItem>> GetVehicleSelectListAsync(long ssn)
        {
            var vehicleList = new List<SelectListItem>();

            var user = await _db.User
                .Include(u => u.Vehicles)
                .FirstOrDefaultAsync(u => u.SSN == ssn);

            if (user != null)
            {
                foreach (var vehicle in user.Vehicles)
                {
                    if (vehicle.ParkingSlots.Count == 0)
                    {
                        vehicleList.Add(
                            new SelectListItem 
                            { 
                                Text = $"{vehicle.Make} ({vehicle.RegNr})",
                                Value = vehicle.RegNr.ToString()
                            }
                        );
                    }
                }
            }

            return vehicleList;
        }
    }
}
