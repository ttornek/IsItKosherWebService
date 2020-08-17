using IsItKosherWebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Models
{
    public class KosherCertificationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string RabbiName { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }
        public IEnumerable<KosherSymbol> KosherSymbols { get; set; }


    }
}
