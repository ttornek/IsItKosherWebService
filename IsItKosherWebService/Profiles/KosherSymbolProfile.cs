using AutoMapper;
using IsItKosherWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Profiles
{
    public class KosherSymbolProfile : Profile
    {
        public KosherSymbolProfile()
        {
            CreateMap<Entities.KosherSymbol, KosherSymbolDto>();

            CreateMap<KosherSymbolForCreationDto, Entities.KosherSymbol>();


        }
    }
}
