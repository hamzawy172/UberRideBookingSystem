using AutoMapper;
using UberRideBookingSystem.Dtos.RideDtos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.Mappings
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<Ride, RideDto>();
            CreateMap<CreateRideDto, Ride>();
        }
    }
}
