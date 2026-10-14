using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.UnitOfWoeks
{
    public interface IUnitOfWork
    {
        IGenericRepo<Payment> Payment { get; }
        IGenericRepo<Rating> Rating { get; }
        IGenericRepo<Ride> Ride { get; }
        IGenericRepo<User> User { get; }
        IGenericRepo<Vehicle> Vehicle { get; }

        Task Save();
    }
}
