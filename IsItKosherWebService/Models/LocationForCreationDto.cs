using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Models
{
    public class LocationForCreationDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
