using System.Text;
using Bogus;
using Garage.Entities;
using Garage.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Garage.Data
{
    public class SeedData
    {
         
        
        private static Faker faker = null!;
        static readonly Random rando = new Random();

        public static async Task InitAsync(GarageContext2 db)
        {
            if (await db.User.AnyAsync()) return;

            faker = new Faker("en");
            
            

            var users = GetUsers();
            await db.AddRangeAsync(users);


            var vehicles = GetVehicles(users ,db);
            await db.AddRangeAsync(vehicles);


            await db.SaveChangesAsync();
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

                if (faker.Random.Int(0, 3) == 0)
                {
                    
                    var model = faker.Vehicle.Model();
                    var make = faker.Vehicle.Manufacturer();
                    var color = (VehicleColor)faker.Random.Int(0, max -1);
                    var ran = faker.Random.Int(0,vT.Count -1);
                    var wheelCount = faker.Random.Int(0, 4);
                    var vehicleType = vT[ran];
                    var regId = GetRegId();
                    var Vehicle = new Vehicle(make, model, regId, user, vehicleType, color, wheelCount);
                    vehicles.Add(Vehicle);
                }
            }
            return vehicles;
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
