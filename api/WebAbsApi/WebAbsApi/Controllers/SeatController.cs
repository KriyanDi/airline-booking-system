using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Context;
using WebAbsApi.Data;
using WebAbsApi.IRepository;

namespace WebAbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IAbsRepository _absRepository;

        public SeatController(IAbsRepository absRepository)
        {
           _absRepository = absRepository;
        }

        [HttpPost("Book")]
        public async Task<IActionResult> BookSeat([FromBody] SeatControlDTO seat)
        {
            await _absRepository.BookSeat(seat);
            return NoContent();
        }

        [HttpPost("Unbook")]
        public async Task<IActionResult> UnbookSeat([FromBody] SeatControlDTO seat)
        {
            await _absRepository.UnbookSeat(seat);
            return NoContent();
        }
    }
}
