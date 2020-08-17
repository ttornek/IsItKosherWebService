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
    [ApiController]
    [Route("api/KosherCertifications")]

    public class KosherCertificationsController : ControllerBase
    {
        private readonly IKosherCertificationRepository _kosherCertificationRepository;
        private readonly IMapper _mapper;
        public KosherCertificationsController(IKosherCertificationRepository kosherCertification, IMapper mapper)
        {
            _kosherCertificationRepository = kosherCertification
                ?? throw new ArgumentNullException(nameof(kosherCertification));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KosherCertification>>> GetKosherCertifications(
            [FromQuery] KosherCertificationResourceParameters kosherCertificationResourceParameters)
        {
            var kosherCertsFromRepo = await _kosherCertificationRepository
                .GetKosherCertificationsAsync(kosherCertificationResourceParameters);

            return Ok(_mapper.Map<IEnumerable<KosherCertificationDto>>(kosherCertsFromRepo));
        }

        [HttpGet("{kosherCertificationId}", Name = "GetKosherCertification")]
        public async Task<IActionResult> GetKosherCertificaiton(Guid kosherCertificationId)
        {
            var kosherCertification =
                await _kosherCertificationRepository.GetKosherCertificationAsync(kosherCertificationId);
            if (kosherCertification == null)
            {
                throw new ArgumentNullException(nameof(kosherCertification));

            }
            return Ok(_mapper.Map<KosherCertificationDto>(kosherCertification));
        }

        [HttpPost]
        public async Task<ActionResult<KosherCertificationDto>> CreateKosherCertification(
            KosherCertificationForCreationDto kosherCertification)
        {
            var kosherCertificationEntity = _mapper.Map<Entities.KosherCertification>(kosherCertification);

            _kosherCertificationRepository.AddKosherCertification(kosherCertificationEntity);

            await _kosherCertificationRepository.SaveAsync();

            var kosherCertificationToReturn = _mapper.Map<KosherCertificationDto>(kosherCertificationEntity);

            return CreatedAtRoute("GetKosherCertification",
                new { kosherCertificationId = kosherCertificationToReturn.Id },
                kosherCertificationToReturn);

        }
    }
}
