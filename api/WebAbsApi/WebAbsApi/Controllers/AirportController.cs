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
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebAbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AirportController> _logger;
        private readonly IMapper _mapper;


        public AirportController(IConfiguration configuration, ILogger<AirportController> logger, IMapper mapper)
        {
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string q = @"SELECT * FROM AIRPORT";


        }
    }
}
