using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Entities
{
    public class KosherSymbol
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageDescription { get; set; }

        [Required]
        [Column(TypeName ="image")]
        public byte[] Image { get; set; }

        [ForeignKey("KosherCertificationId")]
        public KosherCertification KosherCertification { get; set; }
        public Guid KosherCertificationId { get; set; }
    }
}
