using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Models
{
    public class KosherSymbolDto
    {
        public Guid Id { get; set; }
        public string ImageDescription { get; set; } 
        public byte[] Image { get; set; }  

    }
}
