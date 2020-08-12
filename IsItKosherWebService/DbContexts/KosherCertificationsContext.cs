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

    }
}
