using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.IRepository;

namespace WebAbsApi.Controllers
{
    [Route("api/airports")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAbsRepository _absRepository;

        public AirportsController(IAbsRepository absRepository)
        {
            _absRepository = absRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            var airports = await _absRepository.GetAirports();
            return Ok(airports);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAirportById(Guid id)
        {
            var airport = await _absRepository.GetAirport(id);
            return Ok(airport);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAirport([FromBody] CreateAirportDTO airportDTO)
        {
            var airport = await _absRepository.CreateAirport(airportDTO);
            return CreatedAtRoute("GetAirportById", new { id = airport.AirportId }, airport);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateAirport(Guid id, [FromBody] CreateAirportDTO airportDTO)
        {
            var airport = await _absRepository.GetAirport(id);

            if(airport == null)
            {
                return NotFound();
            }

            await _absRepository.UpdateAirport(id, airportDTO);

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAirprot(Guid id)
        {
            var airport = await _absRepository.GetAirport(id);

            if (airport == null)
            {
                return NotFound();
            }

            await _absRepository.DeleteAirport(id);

            return NoContent();
        }
    }
}
