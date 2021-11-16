using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.IRepository;

namespace WebAbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IAbsRepository _absRepository;

        public FlightsController(IAbsRepository absRepository)
        {
            _absRepository = absRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _absRepository.GetFlights();
            return Ok(flights);
        }

        [HttpGet("Info")]
        public async Task<IActionResult> GetFlightsInfo()
        {
            var flightsInformation = await _absRepository.GetFlightsInformation();
            return Ok(flightsInformation);
        }

        [HttpGet("Info/{id:Guid}", Name = "GetFlightInformationById")]
        public async Task<IActionResult> GetFlightInformationById(Guid id)
        {
            var flight = await _absRepository.GetFlightInformation(id);
            return Ok(flight);
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailableFlights()
        {
            var availableFlights = await _absRepository.GetAvailableFlights();
            return Ok(availableFlights);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchFlights(string origin, string destination)
        {
            var searchedFlights = await _absRepository.SearchFlights(origin, destination);
            return Ok(searchedFlights);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDTO flightDTO)
        {
            var flight = await _absRepository.CreateFlight(flightDTO);
            return CreatedAtRoute("GetFlightInformationById", new { id = flight.Flight_Id }, flight);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlight(Guid id, [FromBody] CreateFlightDTO flightDTO)
        {
            var flight = await _absRepository.GetFlightInformation(id);

            if (flight == null)
            {
                return NotFound();
            }

            await _absRepository.UpdateFlight(id, flightDTO);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            var flight = await _absRepository.GetFlightInformation(id);

            if (flight == null)
            {
                return NotFound();
            }

            await _absRepository.DeleteFlight(id);

            return NoContent();
        }
    }
}
