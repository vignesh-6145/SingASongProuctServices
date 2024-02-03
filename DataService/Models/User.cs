using System.ComponentModel.DataAnnotations;
namespace DataService.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

        public UserRole Role { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;

        public string AddressLine { get; set; } = null!;
        public string City { get; set; } = null!;   //Place
        [MinLength(6), MaxLength(6)]
        public string? Pin { get; set; } = null!;
        public int? StateID { get; set; }
        public State? State { get; set; } = null!;
        public int? CountryID { get; set; }
        public Country? Country { get; set; } = null!;
        //public List<UserTracks> tracks { get; set; } = null!;
    }
}
