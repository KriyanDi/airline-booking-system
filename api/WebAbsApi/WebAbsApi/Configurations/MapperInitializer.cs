﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.Models;

namespace WebAbsApi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Airport, CreateAirportDTO>().ReverseMap();

            CreateMap<Airline, AirlineDTO>().ReverseMap();
            CreateMap<Airline, CreateAirlineDTO>().ReverseMap();

            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<Flight, CreateFlightDTO>().ReverseMap();
        }
    }
}
