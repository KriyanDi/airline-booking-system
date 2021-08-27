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
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TicketController> _logger;
        private readonly IMapper _mapper;

        public TicketController(IUnitOfWork unitOfWork, ILogger<TicketController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _unitOfWork.Tickets.GetAll();
            var results = _mapper.Map<IList<TicketDTO>>(tickets);
            return Ok(results);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id:int}", Name = "GetTicket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);
            var result = _mapper.Map<TicketDTO>(ticket);
            return Ok(result);
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateTicket)}");
                return BadRequest(ModelState);
            }

            var ticket = _mapper.Map<Ticket>(ticketDTO);
            await _unitOfWork.Tickets.Insert(ticket);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] UpdateTicketDTO ticketDTO)
        {
            if (!ModelState.IsValid || id < 0)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateTicket)}");
                return BadRequest(ModelState);
            }

            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);
            if (ticket == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateTicket)}");
                return BadRequest("Submitted data is invalid.");
            }

            _mapper.Map(ticketDTO, ticket);
            _unitOfWork.Tickets.Update(ticket);
            await _unitOfWork.Save();

            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attmpet in {nameof(DeleteTicket)}");
                return BadRequest();
            }

            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);
            if (ticket == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteTicket)}");
                return BadRequest("Submitted data is invalid.");
            }

            await _unitOfWork.Tickets.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
