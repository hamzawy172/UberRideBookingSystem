using AutoMapper;
using UberRideBookingSystem.Dtos.VehicleDtos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<UpdateVehicleDto, Vehicle>();
            CreateMap<CreateVehicleDto, Vehicle>();
        }
    }
}
