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
            return _context.KosherCertifications.ToList<KosherCertification>();

        }

        public KosherSymbol GetKosherSymbol(Guid kosherCertificationId, Guid kosherSymbolId)
        {

            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            if (kosherSymbolId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherSymbolId));
            }

           return _context.KosherSymbols
                .Where(k => k.KosherCertificationId == kosherCertificationId && k.Id == kosherSymbolId)
                .FirstOrDefault();
        }

        public IEnumerable<KosherSymbol> GetKosherSymbols(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return _context.KosherSymbols
                .Where(ks => ks.KosherCertificationId == kosherCertificationId).ToList();
        }

        public IEnumerable<Location> GetLocations(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return _context.Locations
                .Where(l => l.KosherCertificationId==kosherCertificationId).ToList();
        }

        public bool KosherCertificationExists(Guid kosherCertificationId)
        {

            if (kosherCertificationId ==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }
            return _context.KosherCertifications.Any(k=>k.Id==kosherCertificationId);
        }

        public bool Save()
        {
         return _context.SaveChanges()>0;
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
