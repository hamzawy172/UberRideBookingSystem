using UberRideBookingSystem.CustemRepos.RideRepos;
using UberRideBookingSystem.CustemRepos.UserRepos;
using UberRideBookingSystem.CustemRepos.VehicleRepos;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.UnitOfWoeks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepo<Payment> Payment { get; }

        public IGenericRepo<Rating> Rating {  get; }

        public IRideRepo Ride { get; }

        public IUserRepo User { get; }

        public IVehicleRepo Vehicle { get; }

        public IAuthRepo Auth {  get; }

        private readonly MyContext c;
        public UnitOfWork(MyContext c , IGenericRepo<Payment> Payment , IGenericRepo<Rating> Rating , IRideRepo Ride , IUserRepo User , IVehicleRepo Vehicle , IAuthRepo Auth)
        {
            this.Ride = Ride;
            this.Payment = Payment;
            this.User = User;
            this.Vehicle = Vehicle;
            this.Rating = Rating;
            this.Auth = Auth;

            this.c = c;
        }

        public async Task Save()
        {
            await c.SaveChangesAsync();
        }
    }
}
