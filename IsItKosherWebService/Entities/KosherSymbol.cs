using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IsItKosherWebService.Entities
{
    public class KosherSymbol
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageDescription { get; set; }

     
        [Column(TypeName ="image")]
        public byte[] Image { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("KosherCertificationId")]
        public KosherCertification KosherCertification { get; set; }
        public Guid KosherCertificationId { get; set; }
    }
}
