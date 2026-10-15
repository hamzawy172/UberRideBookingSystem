using Microsoft.EntityFrameworkCore;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.VehicleRepos
{
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicleRepo
    {
        private readonly MyContext c;
        public VehicleRepo(MyContext c) : base(c)
        {
            this.c = c;
        }

        public async Task<bool> HasVehicle(int id)
        {
            var data = await c.vehicles.AnyAsync(a => a.DriverId == id);
            return data;
        }
    }
}
