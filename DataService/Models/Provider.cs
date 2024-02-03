using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{
    public class Provider { 
        public int ProviderID { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
