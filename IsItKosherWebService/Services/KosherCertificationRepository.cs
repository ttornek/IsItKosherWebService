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
            if (kosherCertification == null)
            {
                throw new ArgumentNullException(nameof(kosherCertification));
            }
        //    kosherCertification.Id = Guid.NewGuid();
            //foreach (var kosherSymbol in kosherCertification.KosherSymbols)
            //{
            //    kosherSymbol.Id = Guid.NewGuid();
            //}
            //foreach (var location in kosherCertification.Locations)
            //{
            //    location.Id = Guid.NewGuid();
            //}
            _context.KosherCertifications.Add(kosherCertification);

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
            if (kosherCertificationResourseParams == null)
            {
                throw new ArgumentNullException(nameof(kosherCertificationResourseParams));
            }

            if (string.IsNullOrWhiteSpace(kosherCertificationResourseParams.Name) 
                && string.IsNullOrWhiteSpace(kosherCertificationResourseParams.SearchQuery))
            {
                return GetKosherCertifications();
            }
            var collection = _context.KosherCertifications as IQueryable<KosherCertification>;
            //filter
            if (!string.IsNullOrWhiteSpace(kosherCertificationResourseParams.Name))
            {
                var name = kosherCertificationResourseParams.Name.Trim();
                collection = _context.KosherCertifications.Where(k => k.Name == name);
            }
            //search the koshercertificatons 
            if (!string.IsNullOrWhiteSpace(kosherCertificationResourseParams.SearchQuery))
            {
                var searchQuery = kosherCertificationResourseParams.SearchQuery.Trim();
                collection = collection.Where(k => k.Name.Contains(searchQuery)
                 || k.RabbiFirstName.Contains(searchQuery)
                 || k.RabbiLastName.Contains(searchQuery)
                 || k.PhoneNumber.Contains(searchQuery)
                 || k.Locations.Any(l => l.Country.Contains(searchQuery)
                 ||l.City.Contains(searchQuery)
                 ||l.ZipCode==int.Parse(searchQuery)
                 ||l.Street.Contains(searchQuery)));
                
                
            }


            return collection.ToList();
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
