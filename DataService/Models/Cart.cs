using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataService.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int Status { get; set; }

        //public ICollection<CartTrack> Tracks { get; set; } = null!;
    }
}