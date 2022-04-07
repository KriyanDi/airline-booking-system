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
    public class FlightSectionsController : ControllerBase
    {
        private readonly IAbsRepository _absRepository;

        public FlightSectionsController(IAbsRepository absRepository)
        {
            _absRepository = absRepository;
        }

        [HttpGet("AllSeatclasses")]
        public async Task<IActionResult> GetSeatclasses()
        {
            var seatclasses = await _absRepository.GetSeatclasses();
            return Ok(seatclasses);
        }

        [HttpGet(Name = "GetFlightSection")]
        public async Task<IActionResult> GetFlightSection(Guid flight_id, Guid seatclass_id)
        {
            var flight_section = await _absRepository.GetFlightSection(flight_id,seatclass_id);
            return Ok(flight_section);
        }

        [HttpGet("AddedSeatclasses/{flight_id:Guid}")]
        public async Task<IActionResult> GetAddedSeatclasses(Guid flight_id)
        {
            var added = await _absRepository.GetAddedSeatclasses(flight_id);
            return Ok(added);
        }

        [HttpGet("NotAddedSeatclasses/{flight_id:Guid}")]
        public async Task<IActionResult> GetNotAddedSeatclasses(Guid flight_id)
        {
            var notAdded = await _absRepository.GetNotAddedSeatclasses(flight_id);
            return Ok(notAdded);
        }

        [HttpGet("AllSeats")]
        public async Task<IActionResult> GetSectionAllSeats(Guid flight_id, Guid seatclass_id)
        {
            var all = await _absRepository.GetSectionSeats(flight_id, seatclass_id);
            return Ok(all);
        }

        [HttpGet("FreeSeats")]
        public async Task<IActionResult> GetSectionFreeSeats(Guid flight_id, Guid seatclass_id)
        {
            var free = await _absRepository.GetSectionFreeSeats(flight_id, seatclass_id);
            return Ok(free);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlightSection([FromBody] CreateFlightSectionDTO section)
        {
            var flight_section = await _absRepository.CreateFlightSection(section);
            return CreatedAtRoute("GetFlightSection", new { flight_section.Flight_Id, flight_section.Seatclass_Id }, flight_section);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlightSection(Guid flight_id, Guid seatclass_id)
        { 
            var flight_section = await _absRepository.GetFlightSection(flight_id, seatclass_id);

            if (flight_section == null)
            {
                return BadRequest();
            }

            await _absRepository.DeleteFlightSection(flight_id, seatclass_id);

            return NoContent();
        }
    }
}
