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
    public class AirlineController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AirlineController> _logger;
        private readonly IMapper _mapper;

        public AirlineController(IUnitOfWork unitOfWork, ILogger<AirlineController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAirlines()
        {
            var airlines = await _unitOfWork.Airlines.GetAll();
            var results = _mapper.Map<IList<AirlineShortDTO>>(airlines);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetAirline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAirline(int id)
        {
            var airline = await _unitOfWork.Airlines.Get(q => q.Id == id, new List<string>{"Flights"});
            var result = _mapper.Map<AirlineDTO>(airline);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAirline([FromBody] CreateAirlineDTO airlineDTO)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateAirline)}");
                return BadRequest(ModelState);
            }

            var airline = _mapper.Map<Airline>(airlineDTO);
            await _unitOfWork.Airlines.Insert(airline);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetAirline", new { id = airline.Id }, airline);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAirline(int id, [FromBody] UpdateAirlineDTO airlineDTO)
        {
            if(!ModelState.IsValid || id < 0)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAirline)}");
                return BadRequest(ModelState);
            }

            var airline = await _unitOfWork.Airlines.Get(q => q.Id == id);
            if(airline == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAirline)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(airlineDTO, airline);
            _unitOfWork.Airlines.Update(airline);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            if(id < 1)
            {
                _logger.LogError($"Invalid DELETE attmpet in {nameof(DeleteAirline)}");
                return BadRequest();
            }

            var airline = await _unitOfWork.Airlines.Get(q => q.Id == id);
            if(airline == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAirline)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.Airlines.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
