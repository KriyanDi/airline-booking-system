﻿using AutoMapper;
using WebAbsApi.Data;
using WebAbsApi.Models;

namespace WebAbsApi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Airport, AirportDTO>().ReverseMap();
            //CreateMap<Airport, AirportShortDTO>().ReverseMap();
            //CreateMap<Airport, CreateAirportDTO>().ReverseMap();
            //CreateMap<Airport, UpdateAirportDTO>().ReverseMap();

            //CreateMap<Airline, AirlineDTO>().ReverseMap();
            //CreateMap<Airline, AirlineShortDTO>().ReverseMap();
            //CreateMap<Airline, CreateAirlineDTO>().ReverseMap();
            //CreateMap<Airline, UpdateAirlineDTO>().ReverseMap();

            //CreateMap<Flight, FlightDTO>().ReverseMap();
            //CreateMap<Flight, FlightShortDTO>().ReverseMap();
            //CreateMap<Flight, CreateFlightDTO>().ReverseMap();
            //CreateMap<Flight, UpdateFlightDTO>().ReverseMap();

            //CreateMap<FlightSection, FlightSectionDTO>().ReverseMap();
            //CreateMap<FlightSection, FlightSectionShortDTO>().ReverseMap();
            //CreateMap<FlightSection, CreateFlightSectionDTO>().ReverseMap();
            //CreateMap<FlightSection, UpdateFlightSectionDTO>().ReverseMap();
            
            //CreateMap<Seat, SeatDTO>().ReverseMap();
            //CreateMap<Seat, SeatShortDTO>().ReverseMap();
            //CreateMap<Seat, CreateSeatDTO>().ReverseMap();
            //CreateMap<Seat, UpdateSeatDTO>().ReverseMap();

            //CreateMap<ApiUser, UserDTO>().ReverseMap();
            ////CreateMap<ApiUser, LoginDTO>().ReverseMap();

            //CreateMap<Ticket, TicketDTO>().ReverseMap();
            //CreateMap<Ticket, CreateTicketDTO>().ReverseMap();
            //CreateMap<Ticket, UpdateTicketDTO>().ReverseMap();
        }
    }
}
