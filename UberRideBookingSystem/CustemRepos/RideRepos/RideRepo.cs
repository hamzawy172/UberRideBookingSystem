using Microsoft.EntityFrameworkCore;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.RideRepos
{
    public class RideRepo : GenericRepo<Ride>, IRideRepo
    {
        private readonly MyContext c;
        public RideRepo(MyContext c): base(c)
        {
            this.c = c;
        }

        public async Task<List<Ride>> PagedRides(int pageNumber, int pageSize)
        {
            var data = await c.rides.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return data;
        }

        public async Task<List<Ride>> Search(string PakcUp)
        {
            var data = await c.rides.Where(a => a.PickUpLocation.Contains(PakcUp)).ToListAsync();

            return data;
        }
    }
}
