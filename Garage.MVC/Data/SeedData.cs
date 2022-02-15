using Bogus;
using Garage.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garage_2_Group_1.Data
{
    public class SeedData
    {
        private static Faker faker = null!;

        public static async Task InitAsync(GarageContext db)
        {
            if(await db.Vehicle.AnyAsync()) return;

            faker = new Faker("en");

            var vehicles = GetVehicles();
            await db.AddRangeAsync(vehicles);


            var users = GetUsers();
            await db.AddRangeAsync(users);








            await db.SaveChangesAsync();
        }

        private static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            for (int i = 0; i < 50; i++)
            {
                
            }
        }

        private static object GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
