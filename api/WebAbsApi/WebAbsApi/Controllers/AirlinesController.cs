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
    public class AirlinesController : ControllerBase
    {
        private readonly IAbsRepository _absRepository;

        public AirlinesController(IAbsRepository absRepository)
        {
            _absRepository = absRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirlines()
        {
            var airlines = await _absRepository.GetAirlines();
            return Ok(airlines);
        }

        [HttpGet("{id:Guid}", Name = "GetAirlineById")]
        public async Task<IActionResult> GetAirlineById(Guid id)
        {
            var airline = await _absRepository.GetAirline(id);
            return Ok(airline);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAirline([FromBody] CreateAirlineDTO airlineDTO)
        {
            var airline = await _absRepository.CreateAirline(airlineDTO);
            return CreatedAtRoute("GetAirlineById", new { id = airline.Airline_Id }, airline);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateAirline(Guid id, [FromBody] CreateAirlineDTO airlineDTO)
        {
            var airline = await _absRepository.GetAirline(id);

            if (airline == null)
            {
                return NotFound();
            }

            await _absRepository.UpdateAirline(id, airlineDTO);

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAirline(Guid id)
        {
            var airline = await _absRepository.GetAirline(id);

            if (airline == null)
            {
                return NotFound();
            }

            await _absRepository.DeleteAirline(id);

            return NoContent();
        }
    }
}
