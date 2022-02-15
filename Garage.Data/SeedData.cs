using System.Text;
using Bogus;
using Garage.Entities;
using Garage.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Garage_2_Group_1.Data
{
    public class SeedData
    {
        private static Faker faker = null!;
        static readonly Random rando = new Random();

        public static async Task InitAsync(GarageContext db)
        {
            if(await db.Vehicle.AnyAsync()) return;

            faker = new Faker("en");



            var users = GetUsers();
            await db.AddRangeAsync(users);


            var vehicles = GetVehicles(users);
            await db.AddRangeAsync(vehicles);







            await db.SaveChangesAsync();
        }

        private static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            for (int i = 0; i < 20; i++)
            {
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                var avatar = faker.Internet.Avatar();

                var user = new User(lastName, firstName, avatar);
                users.Add(user);
            }
            return users;

        }

        private static IEnumerable<Vehicle> GetVehicles(IEnumerable<User> users)
        {
            var vehicles = new List<Vehicle>();
            foreach (var user in users)
            {

                if (faker.Random.Int(0, 3) == 0)
                {
                    var regId = GetRegId();
                    var Vehicle = new Vehicle()
                    {
                        RegNr = regId,
                        Model = faker.Vehicle.Model(),
                        Make = faker.Vehicle.Manufacturer(),
                        User = user,
                        // ToDo: Add a random VehicleType, it'll be null now.
                        WheelCount = faker.Random.Int(0, 4),
                        Color = RandomEnumValue<VehicleColor>()

                    };
                    vehicles.Add(Vehicle);
                }
            }
            return vehicles;
        }

        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(rando.Next(v.Length))!;
        }

        private static string GetRegId()
        {


            // ToDo: Make a Do-While !UniqueRegId on this to make sure all the random generated regId's are Unique.

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(faker.Random.String2(3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            stringBuilder.Append(faker.Random.Number(100, 999));

            return stringBuilder.ToString();

            

        }
    }
}
