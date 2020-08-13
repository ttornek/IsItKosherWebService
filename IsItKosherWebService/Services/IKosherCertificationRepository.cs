using IsItKosherWebService.Entities;
using IsItKosherWebService.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsItKosherWebService.Services
{
    public interface IKosherCertificationRepository
    {
        void AddKosherCertification(KosherCertification kosherCertification);
        Task AddKosherCertificationAsync(KosherCertification kosherCertification);
        void DeleteKosherCertification(KosherCertification kosherCertification);
        void Dispose();
        KosherCertification GetKosherCertification(Guid kosherCertificationId);
        IEnumerable<KosherCertification> GetKosherCertification(KosherCertificationResourceParameters kosherCertificationResourseParams);
        Task<KosherCertification> GetKosherCertificationAsync(Guid kosherCertificationId);
        IEnumerable<KosherCertification> GetKosherCertifications();
        Task<IEnumerable<KosherCertification>> GetKosherCertificationsAsync(KosherCertificationResourceParameters kosherCertificationResourceParams);
        KosherSymbol GetKosherSymbol(Guid kosherCertificationId, Guid kosherSymbolId);
        Task<KosherSymbol> GetKosherSymbolAsync(Guid kosherCertificationId, Guid kosherSymbolId);
        IEnumerable<KosherSymbol> GetKosherSymbols(Guid kosherCertificationId);
        Task<IEnumerable<KosherSymbol>> GetKosherSymbolsAsync(Guid kosherCertificationId);
        IEnumerable<Location> GetLocations(Guid kosherCertificationId);
        Task<IEnumerable<Location>> GetLocationsAsync(Guid kosherCertificationId);
        bool KosherCertificationExists(Guid kosherCertificationId);
        Task<bool> KosherCertificationExistsAsync(Guid kosherCertificationId);
        bool Save();
        Task<bool> SaveAsync();
    }
}