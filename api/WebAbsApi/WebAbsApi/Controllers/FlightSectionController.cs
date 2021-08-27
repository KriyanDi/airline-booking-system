using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.IRepository;
using WebAbsApi.Models;

namespace WebAbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightSectionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FlightSectionController> _logger;
        private readonly IMapper _mapper;

        public FlightSectionController(IUnitOfWork unitOfWork, ILogger<FlightSectionController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFlightSections()
        {
            var flightSections = await _unitOfWork.FlightSections.GetAll();
            var results = _mapper.Map<IList<FlightSectionDTO>>(flightSections);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetFlightSection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFlightSection(int id)
        {
            var flightSection = await _unitOfWork.FlightSections.Get(q => q.Id == id, new List<string> {"Flight","Seats"});
            var result = _mapper.Map<FlightSectionDTO>(flightSection);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFlightSection([FromBody] CreateFlightSectionDTO flightSectionDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateFlightSection)}");
                return BadRequest(ModelState);
            }

            var flightSection = _mapper.Map<FlightSection>(flightSectionDTO);
            await _unitOfWork.FlightSections.Insert(flightSection);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetFlightSection", new { id = flightSection.Id }, flightSection);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFlightSection(int id, [FromBody] UpdateFlightSectionDTO flightSectionDTO)
        {
            if (!ModelState.IsValid || id < 0)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFlightSection)}");
                return BadRequest(ModelState);
            }

            var flightSection = await _unitOfWork.FlightSections.Get(q => q.Id == id);
            if (flightSection == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFlightSection)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(flightSectionDTO, flightSection);
            _unitOfWork.FlightSections.Update(flightSection);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFlightSection(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attmpet in {nameof(DeleteFlightSection)}");
                return BadRequest();
            }

            var flightSection = await _unitOfWork.FlightSections.Get(q => q.Id == id);
            if (flightSection == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFlightSection)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.FlightSections.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
