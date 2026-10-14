using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.UnitOfWoeks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepo<Payment> Payment { get; }

        public IGenericRepo<Rating> Rating {  get; }

        public IGenericRepo<Ride> Ride { get; }

        public IGenericRepo<User> User { get; }

        public IGenericRepo<Vehicle> Vehicle { get; }
        private readonly MyContext c;
        public UnitOfWork(MyContext c , IGenericRepo<Payment> Payment , IGenericRepo<Rating> Rating , IGenericRepo<Ride> Ride , IGenericRepo<User> User , IGenericRepo<Vehicle> Vehicle)
        {
            this.Ride = Ride;
            this.Payment = Payment;
            this.User = User;
            this.Vehicle = Vehicle;
            this.Rating = Rating;

            this.c = c;
        }

        public async Task Save()
        {
            await c.SaveChangesAsync();
        }
    }
}
