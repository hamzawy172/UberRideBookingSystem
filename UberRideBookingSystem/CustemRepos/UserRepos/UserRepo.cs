using Microsoft.EntityFrameworkCore;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.UserRepos
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private MyContext c;
        public UserRepo(MyContext c) : base(c) 
        {
            this.c = c;
        }

        public async Task<List<User>> GetDrivers()
        {
            var data = await c.users.Where(a => a.Role == "Driver").ToListAsync();

            return data;
        }

        public async Task<List<User>> SearchUSersByName(string name)
        {
            var data = await c.users.Where(a => a.FullName.Contains(name)).ToListAsync();

            return data;
        }
    }
}
