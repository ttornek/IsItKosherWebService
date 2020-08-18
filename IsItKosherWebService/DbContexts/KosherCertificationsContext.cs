using IsItKosherWebService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.DbContexts
{
    public class KosherCertificationsContext :DbContext
    {
        public KosherCertificationsContext(DbContextOptions<KosherCertificationsContext> options)
            : base(options)
        { }
        public DbSet<KosherCertification> KosherCertifications { get; set; }
        public DbSet<KosherSymbol> KosherSymbols { get; set; }

        public DbSet<Location> Locations { get; set; }


        //perhaps seed data here 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KosherCertification>().HasData(
                new KosherCertification()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    RabbiFirstName = "Rabbi Tzvi",
                    PhoneNumber = "6462714233",
                    Name = "Ok Kosher",
                    RabbiLastName="Tornek"
               

                },
                 new KosherCertification()
                 {
                     Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                     RabbiFirstName = "Rabbi Tova",
                     PhoneNumber = "2628945438",
                     Name = "Orthodox Union",
                     RabbiLastName = "Tornek"


                 }
                ) ;
           
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id=Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    KosherCertificationId=Guid.Parse( "d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Longitude=100,
                    Latitude=200,
                    City="brooklyn",
                    State="Ny",
                    Country="USA",
                    ZipCode=11225,
                    Street="1417 east 16th street"
                },
                  new Location
                  {
                      Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                      KosherCertificationId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                      Longitude = -200,
                      Latitude = 1000,
                      City = "brooklyn",
                      State = "Ny",
                      Country = "USA",
                      ZipCode = 11219,
                      Street = "1166 50th street"
                  }


                
                
                );


            modelBuilder.Entity<KosherSymbol>().HasData(

                new KosherSymbol
                {
                    Image = new byte[0],
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    KosherCertificationId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ImageDescription = "k inside of a circle"
                },
                 new KosherSymbol
                 {
                     Image = new byte[0],
                     Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                     KosherCertificationId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                     ImageDescription = "U inside of a circle"
                 }

                ) ;
            base.OnModelCreating(modelBuilder);
        }

    }
}
