using UberRideBookingSystem.CustemRepos.RideRepos;
using UberRideBookingSystem.CustemRepos.UserRepos;
using UberRideBookingSystem.CustemRepos.VehicleRepos;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.UnitOfWoeks
{
    public interface IUnitOfWork
    {
        IGenericRepo<Payment> Payment { get; }
        IGenericRepo<Rating> Rating { get; }
        IRideRepo Ride { get; }
        IUserRepo User { get; }
        IVehicleRepo Vehicle { get; }
        IAuthRepo Auth { get; }

        Task Save();
    }
}
