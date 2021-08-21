using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAbsApi.Data;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAirports()
        {
            var airports = await _unitOfWork.Airports.GetAll();
            var results = _mapper.Map<IList<AirportDTO>>(airports);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetAirport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAirport(int id)
        {
            var airport = await _unitOfWork.Airports.Get(q => q.Id == id, new List<string> { "OriginToFlights", "DestinationToFlights" });
            var result = _mapper.Map<AirportDTO>(airport);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAirport([FromBody] CreateAirportDTO airportDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateAirport)}");
                return BadRequest(ModelState);
            }

            var airport = _mapper.Map<Airport>(airportDTO);
            await _unitOfWork.Airports.Insert(airport);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetAirport", new { id = airport.Id }, airport);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAirport(int id, [FromBody] UpdateAirportDTO airportDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAirport)}");
                return BadRequest(ModelState);
            }

            var airport = await _unitOfWork.Airports.Get(q => q.Id == id);
            if (airport == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAirport)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(airportDTO, airport);
            _unitOfWork.Airports.Update(airport);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAirport)}");
                return BadRequest();
            }

            var airport = await _unitOfWork.Airports.Get(q => q.Id == id);
            if (airport == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAirport)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.Airports.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
