using IsItKosherWebService.DbContexts;
using IsItKosherWebService.Entities;
using IsItKosherWebService.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Services
{
    public class KosherCertificationRepository : IDisposable, IKosherCertificationRepository
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
            _context.KosherCertifications.AddAsync(kosherCertification);

        }

        public async Task AddKosherCertificationAsync(KosherCertification kosherCertification)
        {

            if (kosherCertification == null)
            {
                throw new ArgumentNullException(nameof(kosherCertification));
            }

            await _context.KosherCertifications.AddAsync(kosherCertification);

        }

        public void DeleteKosherCertification(KosherCertification kosherCertification)
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
                  .Where(k => k.Id == kosherCertificationId).Include(k=>k.Locations).Include(k=>k.KosherSymbols).FirstOrDefault();
        }

        public async Task<KosherCertification> GetKosherCertificationAsync(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return await _context.KosherCertifications
                  .Where(k => k.Id == kosherCertificationId).FirstOrDefaultAsync();
        }

        public IEnumerable<KosherCertification> GetKosherCertifications(KosherCertificationResourceParameters kosherCertificationResourseParams)
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


            return BuildSearchCollection(kosherCertificationResourseParams).ToList();

        }

        public async Task<IEnumerable<KosherCertification>> GetKosherCertificationsAsync(KosherCertificationResourceParameters kosherCertificationResourceParams)
        {
            if (kosherCertificationResourceParams == null)
            {
                throw new ArgumentNullException(nameof(kosherCertificationResourceParams));
            }

            if (string.IsNullOrWhiteSpace(kosherCertificationResourceParams.Name)
                && string.IsNullOrWhiteSpace(kosherCertificationResourceParams.SearchQuery))
            {
                return GetKosherCertificationsAsync() as IEnumerable<KosherCertification>;
            }
            return await BuildSearchCollection(kosherCertificationResourceParams).ToListAsync();
        }


        private IQueryable<KosherCertification> BuildSearchCollection(KosherCertificationResourceParameters kosherCertificationResourseParams)
        {
            var collection = _context.KosherCertifications as IQueryable<KosherCertification>;
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
                 || l.City.Contains(searchQuery)
                 || l.ZipCode.ToString().Contains(searchQuery)
                 || l.Street.Contains(searchQuery)));


            }
            return collection;
        }

        public IEnumerable<KosherCertification> GetKosherCertifications()
        {
            return _context.KosherCertifications.ToList();

        }

        private async Task<IEnumerable<KosherCertification>> GetKosherCertificationsAsync()
        {
            return await _context.KosherCertifications.ToListAsync();
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
        public async Task<KosherSymbol> GetKosherSymbolAsync(Guid kosherCertificationId, Guid kosherSymbolId)
        {

            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            if (kosherSymbolId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherSymbolId));
            }

            return await _context.KosherSymbols
                 .Where(k => k.KosherCertificationId == kosherCertificationId && k.Id == kosherSymbolId)
                 .FirstOrDefaultAsync();
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
        public async Task<IEnumerable<KosherSymbol>> GetKosherSymbolsAsync(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return await _context.KosherSymbols
                .Where(ks => ks.KosherCertificationId == kosherCertificationId).ToListAsync();
        }

        public IEnumerable<Location> GetLocations(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return _context.Locations
                .Where(l => l.KosherCertificationId == kosherCertificationId).ToList();
        }
        public async Task<IEnumerable<Location>> GetLocationsAsync(Guid kosherCertificationId)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }

            return await _context.Locations
                .Where(l => l.KosherCertificationId == kosherCertificationId).ToListAsync();
        }

        public bool KosherCertificationExists(Guid kosherCertificationId)
        {

            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }
            return _context.KosherCertifications.Any(k => k.Id == kosherCertificationId);
        }
        public async Task<bool> KosherCertificationExistsAsync(Guid kosherCertificationId)
        {

            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }
            return await _context.KosherCertifications.AnyAsync(k => k.Id == kosherCertificationId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public void AddKosherSymbol(Guid kosherCertificationId, KosherSymbol kosherSymbol)
        {
            if (kosherCertificationId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(kosherCertificationId));
            }
            if (kosherSymbol == null)
            {
                throw new ArgumentNullException(nameof(kosherSymbol));
            }

            kosherSymbol.KosherCertificationId = kosherCertificationId;
            _context.KosherSymbols.Add(kosherSymbol);
        }


    }

}
