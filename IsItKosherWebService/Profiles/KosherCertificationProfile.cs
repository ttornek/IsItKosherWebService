using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Profiles
{
    public class KosherCertificationProfile : Profile
    {
        public KosherCertificationProfile()
        {
            CreateMap<Entities.KosherCertification, Models.KosherCertificationDto>()
                .ForMember(
                dest => dest.RabbiName, opt => opt.MapFrom(
                    src => $"{src.RabbiFirstName} {src.RabbiLastName}"));

            CreateMap<Models.KosherCertificationForCreationDto, Entities.KosherCertification>();



        }

    }
}
