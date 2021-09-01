using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class FlightController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FlightController> _logger;
        private readonly IMapper _mapper;

        public FlightController(IUnitOfWork unitOfWork, ILogger<FlightController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _unitOfWork.Flights.GetAll();
            var results = _mapper.Map<IList<FlightShortDTO>>(flights);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFlight(int id)
        {
            //TO DO:
            var flight = await _unitOfWork.Flights.Get(q => q.Id == id, new List<string> { "Airline", "OriginAirport", "DestinationAirport", "FlightSections"});
            if (flight != null && flight.FlightSections.Count != 0)
            {
                foreach (var flightSection in flight.FlightSections)
                {
                    var flightSectionTemp = await _unitOfWork.FlightSections.Get(q => q.Id == flightSection.Id, new List<string> { "Flight", "Seats" });
                    flightSection.Seats = flightSectionTemp.Seats;
                }
            }
            var result = _mapper.Map<FlightDTO>(flight);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateFlight)}");
                return BadRequest(ModelState);
            }

            var flight = _mapper.Map<Flight>(flightDTO);
            await _unitOfWork.Flights.Insert(flight);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetFlight", new { id = flight.Id }, flight);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] UpdateFlightDTO flightDTO)
        {
            if (!ModelState.IsValid || id < 0)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFlight)}");
                return BadRequest(ModelState);
            }

            var flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            if (flight == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFlight)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(flightDTO, flight);
            _unitOfWork.Flights.Update(flight);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attmpet in {nameof(DeleteFlight)}");
                return BadRequest();
            }

            var flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            if (flight == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFlight)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.Flights.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
