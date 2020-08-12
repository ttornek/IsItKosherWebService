using IsItKosherWebService.Entities;
using IsItKosherWebService.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Services
{
    interface IKosherCertificationRepository
    {
        IEnumerable<Location> GetLocations(Guid kosherCertificationId);
        IEnumerable<KosherSymbol> GetKosherSymbols(Guid kosherCertificationId);
        KosherSymbol GetKosherSymbol(Guid kosherCertificationId, Guid kosherSymbolId);
        IEnumerable<KosherCertification> GetKosherCertifications();
        KosherCertification GetKosherCertification(Guid kosherCertificationId);
        IEnumerable<KosherCertification> GetKosherCertification(KosherCertificationResourceParameters kosherCertificationResourseParams);
        void AddKosherCertification(KosherCertification kosherCertification);
        void DeleteKosherCertification();
        bool KosherCertificationExists(Guid kosherCertificationId);
        bool Save();


    }
}
