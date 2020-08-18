using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IsItKosherWebService.Models;
using IsItKosherWebService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsItKosherWebService.Controllers
{
    [Route("api/kosherCertifications/{kosherCertificationId}/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IKosherCertificationRepository _kosherCertificationRepository;
        private readonly IMapper _mapper;

        public LocationsController(IKosherCertificationRepository kosherCertificationRepository
            , IMapper mapper)
        {
            _kosherCertificationRepository = kosherCertificationRepository
                ?? throw new ArgumentNullException(nameof(kosherCertificationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocationsForKosherCertification(Guid kosherCertificationId)
        {
            if (!await _kosherCertificationRepository.KosherCertificationExistsAsync(kosherCertificationId))
            {
                return NotFound();
            }

            var locationsForKosherCertification =
                await _kosherCertificationRepository.GetLocationsAsync(kosherCertificationId);

            return Ok(_mapper.Map<IEnumerable<LocationDto>>(locationsForKosherCertification));
        }
    

    /*
     * TODO:
     * implement update,delete location for kosherCertification
     * I dont think getting specific location is useful for this use case
     * */
    }  
}
