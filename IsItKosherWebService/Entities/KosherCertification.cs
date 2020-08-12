using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Entities
{
    public class KosherCertification
    {
        [Key]
        public Guid Id { get; set; }
     
        [Required]
        public string Name { get; set; }
        public string RabbiFirstName { get; set; }
        public string RabbiLastName { get; set; }
        public int PhoneNumber { get; set; }

        public List<Location> Locations { get; set; }
        = new List<Location>();
        public List<KosherSymbol> KosherSymbols { get; set; }
        = new List<KosherSymbol>();
    }
}
