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
            
        }
    }
}
