using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Models
{
    public class LocationDto
    {
        public string Country { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public string Coordinates { get; set; }
    }
}
