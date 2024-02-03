﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }

        public int AlbumId { get; set; }
        public decimal Price { get; set; }  
    }
}
