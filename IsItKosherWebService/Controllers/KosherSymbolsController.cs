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
    [Route("api/kosherCertifications/{kosherCertificationId}/kosherSymbols")]
    [ApiController]
    public class KosherSymbolsController : ControllerBase
    {
        private readonly IKosherCertificationRepository _kosherCertificationRepository;
        private readonly IMapper _mapper;
        public KosherSymbolsController(IKosherCertificationRepository kosherCertification, IMapper mapper)
        {
            _kosherCertificationRepository = kosherCertification
                ?? throw new ArgumentNullException(nameof(kosherCertification));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KosherSymbolDto>>> GetKosherSymbolsForKosherCertification(
            Guid kosherCertificationId)
        {
            if (!await _kosherCertificationRepository.KosherCertificationExistsAsync(kosherCertificationId))
            {
                return NotFound();
            }

            var KosherSymbolsForKosherCertification =
                await _kosherCertificationRepository.GetKosherSymbolsAsync(kosherCertificationId);

            return Ok(_mapper.Map<IEnumerable<KosherSymbolDto>>(KosherSymbolsForKosherCertification));
        }

        [HttpGet("{kosherSymbolId}",Name = "GetKosherSymbolForKosherCertification")]
        public async Task<ActionResult<KosherSymbolDto>>GetKosherSymbolForKosherCertification(Guid kosherCertificationId,Guid kosherSymbolId)
        {
            if (!await _kosherCertificationRepository.KosherCertificationExistsAsync(kosherCertificationId))
            {
                return NotFound();
            }

            var kosherSymbolFromRepo =await _kosherCertificationRepository.GetKosherSymbolAsync(kosherCertificationId, kosherSymbolId);
            if (kosherSymbolFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<KosherSymbolDto>(kosherSymbolFromRepo));
        }


        [HttpPost]
        public async Task<ActionResult<KosherSymbolDto>>CreateKosherSymbolForKosherCertification(Guid kosherCertificationId,KosherSymbolForCreationDto kosherSymbolDto)
        {
            if (!await _kosherCertificationRepository.KosherCertificationExistsAsync(kosherCertificationId))
            {
                return NotFound();
            }

            var kosherSymbolEntity = _mapper.Map<Entities.KosherSymbol>(kosherSymbolDto);
            _kosherCertificationRepository.AddKosherSymbol(kosherCertificationId,kosherSymbolEntity);
            await _kosherCertificationRepository.SaveAsync();
            var kosherSymbolToReturn = _mapper.Map<KosherSymbolDto>(kosherSymbolEntity);
            return CreatedAtRoute("GetKosherSymbolForKosherCertification",
                new { kosherCertificationId = kosherCertificationId, kosherSymbolId = kosherSymbolToReturn.Id },kosherSymbolToReturn);
               
        }

        
    }
}
