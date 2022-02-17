
using Garage.Entities.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Entities

{
    public class User
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SSN { get; set; } //Social Security Number
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Avatar { get; set; }
        public string Membership { get; } = "Basic";
        public ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();

        private User()
        {
            LastName = null!;
            FirstName = null!;
            Avatar = null!;
        }
        public User(string lastName, string firstName, string avatar, long sSN)
        {
            LastName = lastName;
            FirstName = firstName;
            Avatar = avatar;
            SSN = sSN;
        }

    }
}