using AutoMapper;
using UberRideBookingSystem.Dtos.UserDtos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.Mappings
{
    public class UserrProfile : Profile
    {
        public UserrProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
