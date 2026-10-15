using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.UserRepos
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<List<User>> GetDrivers();
        Task<List<User>> SearchUSersByName(string name);
    }

}
