using IsItKosherWebService.DbContexts;
using IsItKosherWebService.Entities;
using IsItKosherWebService.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Services
{
    public class KosherCertificationRepository : IKosherCertificationRepository, IDisposable
    {
        private readonly KosherCertificationsContext _context;
        public KosherCertificationRepository(KosherCertificationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddKosherCertification(KosherCertification kosherCertification)
        {
            throw new NotImplementedException();

        }

        public void DeleteKosherCertification()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public KosherCertification GetKosherCertification(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return _context.KosherCertifications
                  .Where(k => k.Id == kosherCertificationId).FirstOrDefault();
        }

        public IEnumerable<KosherCertification> GetKosherCertification(KosherCertificationResourceParameters kosherCertificationResourseParams)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KosherCertification> GetKosherCertifications()
        {
            throw new NotImplementedException();
        }

        public KosherSymbol GetKosherSymbol(Guid kosherCertificationId, Guid kosherSymbolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KosherSymbol> GetKosherSymbols(Guid kosherCertificationId)
        {
            if (kosherCertificationId == null)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return _context.KosherSymbols
                .Where(ks => ks.KosherCertificationId == kosherCertificationId).ToList();
        }

        public IEnumerable<Location> GetLocations(Guid kosherCertificationId)
        {
            throw new NotImplementedException();
        }

        public bool KosherCertificationExists()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
    
}
