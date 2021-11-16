using AutoMapper;
using WebAbsApi.Data;
using WebAbsApi.Models;

namespace WebAbsApi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Airline, AirlineDTO>().ReverseMap();
            CreateMap<FlightsInformation, FlightsInformationDTO>().ReverseMap();
            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<FlightSection, FlightSectionDTO>().ReverseMap();
            CreateMap<Seat, SeatDTO>().ReverseMap();
            CreateMap<Seatclass, SeatclassDTO>().ReverseMap();
        }
    }
}
