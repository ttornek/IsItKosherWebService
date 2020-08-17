using AutoMapper;
using IsItKosherWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsItKosherWebService.Profiles
{
    public class LocationProfile :Profile 
    {
        public LocationProfile()
        {
            CreateMap<Entities.Location, LocationDto>().ForMember(
                dest => dest.Address, opt => opt.MapFrom(
                    src => $"{src.Street} {src.City} {src.State}")).ForMember(
               dest => dest.Coordinates, opt => opt.MapFrom(
                   src => $"{src.Longitude},{src.Latitude}"));

        }
    }
}
