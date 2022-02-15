using Bogus;
using Garage.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Garage.Entities

{
    public class User
    {
        [Key]
        public int SSN { get; set; } //Social Security Number
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Avatar { get; set; }
        public string Membership { get; } = "Basic";
        public ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();

        public User()
        {
            LastName = null!;
            FirstName = null!;
            Avatar = null!;
        }
        public User(string lastName, string firstName, string avatar)
        {
            LastName = lastName;
            FirstName = firstName;
            Avatar = avatar;
        }

    }
}