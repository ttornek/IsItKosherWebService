using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IsItKosherWebService.Entities
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public float Longitude { get; set; }//represent these as coordinates in the Dto 
        public float Latitude { get; set; }

        [JsonIgnore]
        [ForeignKey("KosherCertificationId")]
        public KosherCertification KosherCertification { get; set; }
        public Guid KosherCertificationId { get; set; }

    }


}
