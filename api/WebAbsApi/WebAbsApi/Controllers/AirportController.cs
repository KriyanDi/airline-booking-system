using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.IRepository;
using WebAbsApi.Models;

namespace WebAbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AirportController> _logger;
        private readonly IMapper _mapper;


        public AirportController(IUnitOfWork unitOfWork, ILogger<AirportController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            var airports = await _unitOfWork.Airports.GetAll();
            var results = _mapper.Map<IList<AirportDTO>>(airports);
            return Ok(results);
        }
    }
}
