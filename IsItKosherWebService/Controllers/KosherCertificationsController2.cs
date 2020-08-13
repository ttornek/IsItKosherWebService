using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IsItKosherWebService.Entities;
using IsItKosherWebService.Models;
using IsItKosherWebService.ResourceParameters;
using IsItKosherWebService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsItKosherWebService.Controllers
{
    [Route("api/[KosherCertificatons]")]
    [ApiController]
    public class KosherCertificationsController2 : ControllerBase
    {
        private readonly IKosherCertificationRepository _kosherCertificationRepository;
        private readonly IMapper _mapper;
        public KosherCertificationsController2(IKosherCertificationRepository kosherCertification, IMapper mapper)
        {
            _kosherCertificationRepository = kosherCertification 
                ?? throw new ArgumentNullException(nameof(kosherCertification));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }
     [HttpGet]
        public async Task<ActionResult<IEnumerable<KosherCertification>>>GetKosherCertifications(
         [FromQuery]KosherCertificationResourceParameters kosherCertificationResourceParameters)
        {
            var kosherCertsFromRepo = await _kosherCertificationRepository
                .GetKosherCertificationsAsync(kosherCertificationResourceParameters);

            return Ok(_mapper.Map<IEnumerable<KosherCertificationDto>>(kosherCertsFromRepo));
        }

    }
}
