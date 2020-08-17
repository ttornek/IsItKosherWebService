using IsItKosherWebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Models
{
    public class KosherCertificationForCreationDto 
    {
        public string Name { get; set; }
        public string RabbiFirstName { get; set; }
        public string RabbiLastName { get; set; }
        public string PhoneNumber { get; set; }

        public List<Location> Locations { get; set; }
        = new List<Location>();
        public List<KosherSymbol> KosherSymbols { get; set; }
        = new List<KosherSymbol>();
    }
}
