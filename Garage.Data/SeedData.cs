using Bogus;
using Garage.Entities;
using Garage.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Garage.Data
{
    public class SeedData
    {

        private static Faker faker = null!;
        static readonly Random rando = new Random();

        public static async Task InitAsync(GarageContext2 db, IConfiguration config)
        {

            int cap = int.Parse(config.GetSection("Garage:Capacity").Value);
            if (await db.User.AnyAsync()) return;

            faker = new Faker("en");

            var parkingSlots = GenerateParkingSlots(cap);
            await db.AddRangeAsync(parkingSlots);

            var users = GetUsers();
            await db.AddRangeAsync(users);


            var vehicles = GetVehicles(users, db);
            await db.AddRangeAsync(vehicles);


            await db.SaveChangesAsync();
        }

        private static IEnumerable<ParkingSlot> GenerateParkingSlots(int cap)
        {

            var parkingSlot = new List<ParkingSlot>();

            for (int i = 0; i < cap; i++)
            {
                var slot = new ParkingSlot(null);
                parkingSlot.Add(slot);
            }

            return parkingSlot;
        }

        private static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            for (int i = 0; i < 20; i++)
            {
                var sSN = GetUserSSN();
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                var avatar = faker.Internet.Avatar();

                var user = new User(lastName, firstName, avatar, sSN);
                users.Add(user);
            }
            return users;

        }

        private static long GetUserSSN()
        {
            long month = faker.Random.Number(01, 12);
            long day = faker.Random.Number(01, 28);

            StringBuilder stringToParse = new StringBuilder();
            stringToParse.Append(faker.Random.Number(1920, 2003));

            if (month < 10)
            {
                stringToParse.Append(0);
                stringToParse.Append(month);

            }
            else
            {
                stringToParse.Append(month);
            }

            if (day < 10)
            {
                stringToParse.Append(0);
                stringToParse.Append(day);
            }
            else
            {
                stringToParse.Append(day);
            }

            stringToParse.Append(faker.Random.Number(1000, 9999));



            if (long.TryParse(stringToParse.ToString(), out long sSN))
            {
                return sSN;
            }
            else
            {
                throw new Exception("Error Parsing SSN");
            }
        }

        private static IEnumerable<Vehicle> GetVehicles(IEnumerable<User> users, GarageContext2 db)
        {
            var max = Enum.GetNames(typeof(VehicleColor)).Length;


            List<VehicleType> vT = db.VehicleType.Select(x => x).ToList();
            var vehicles = new List<Vehicle>();
            foreach (var user in users)
            {

                if (faker.Random.Int(0, 2) != 0)
                {
                    for (int i = 0; i < faker.Random.Int(1, 3); i++)
                    {

                        var model = faker.Vehicle.Model();
                        var make = faker.Vehicle.Manufacturer();
                        var color = (VehicleColor)faker.Random.Int(0, max - 1);
                        var ran = faker.Random.Int(0, vT.Count - 1);
                        var wheelCount = faker.Random.Int(0, 4);
                        var vehicleType = vT[ran];
                        var regId = GetRegId();
                        var Vehicle = new Vehicle(make, model, regId, user, vehicleType, color, wheelCount);
                        vehicles.Add(Vehicle);
                    }

                }
            }
            return vehicles;
        }



        private static string GetRegId()
        {
            // ToDo: Make a Do-While !UniqueRegId on this to make sure all the random generated regId's are Unique.

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(faker.Random.String2(3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            stringBuilder.Append(faker.Random.Number(10, 99));

            if (faker.Random.Int(0, 2) != 0)
            {
                stringBuilder.Append(faker.Random.String2(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            }
            else
            {
                stringBuilder.Append(faker.Random.Number(0, 9));
            }

            return stringBuilder.ToString();
        }

    }
}
