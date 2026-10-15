using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.VehicleRepos
{
    public interface IVehicleRepo : IGenericRepo<Vehicle>
    {
        Task<bool> HasVehicle(int id);
    }
}
