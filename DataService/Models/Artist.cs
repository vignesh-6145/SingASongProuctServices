using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public DateOnly DOB { get; set; }
    }
}
