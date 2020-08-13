using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            _kosherCertificationRepository = kosherCertification ?? throw new ArgumentNullException(nameof(kosherCertification));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
     

    }
}
