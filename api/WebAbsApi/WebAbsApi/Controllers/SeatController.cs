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
    public class SeatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SeatController> _logger;
        private readonly IMapper _mapper;

        public SeatController(IUnitOfWork unitOfWork, ILogger<SeatController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSeats()
        {
            var seats = await _unitOfWork.Seats.GetAll();
            var results = _mapper.Map<IList<SeatShortDTO>>(seats);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetSeat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSeat(int id)
        {
            var seat = await _unitOfWork.Seats.Get(q => q.Id == id, new List<string> { "FlightSection" });
            var result = _mapper.Map<SeatDTO>(seat);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSeat([FromBody] CreateSeatDTO seatDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateSeat)}");
                return BadRequest(ModelState);
            }

            var seat = _mapper.Map<Seat>(seatDTO);
            await _unitOfWork.Seats.Insert(seat);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetSeat", new { id = seat.Id }, seat);
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSeat(int id, [FromBody] UpdateSeatDTO seatDTO)
        {
            if (!ModelState.IsValid || id < 0)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateSeat)}");
                return BadRequest(ModelState);
            }

            var seat = await _unitOfWork.Seats.Get(q => q.Id == id);
            if (seat == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateSeat)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(seatDTO, seat);
            _unitOfWork.Seats.Update(seat);
            await _unitOfWork.Save();

            return NoContent();
        }

        //[Authorize(Roles = "User")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attmpet in {nameof(DeleteSeat)}");
                return BadRequest();
            }

            var seat = await _unitOfWork.Seats.Get(q => q.Id == id);
            if (seat == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSeat)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.Seats.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
