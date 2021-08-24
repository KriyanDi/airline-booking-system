using AutoMapper;
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
            CreateMap<Airport, UpdateAirportDTO>().ReverseMap();

            CreateMap<Airline, AirlineDTO>().ReverseMap();
            CreateMap<Airline, CreateAirlineDTO>().ReverseMap();
            CreateMap<Airline, UpdateAirlineDTO>().ReverseMap();

            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<Flight, CreateFlightDTO>().ReverseMap();
            CreateMap<Flight, UpdateFlightDTO>().ReverseMap();

            CreateMap<FlightSection, FlightSectionDTO>().ReverseMap();
            CreateMap<FlightSection, CreateFlightSectionDTO>().ReverseMap();
            CreateMap<FlightSection, UpdateFlightSectionDTO>().ReverseMap();
            
            CreateMap<Seat, SeatDTO>().ReverseMap();
            CreateMap<Seat, CreateSeatDTO>().ReverseMap();
            CreateMap<Seat, UpdateSeatDTO>().ReverseMap();
        }
    }
}
