using UberRideBookingSystem.Dtos.UserDtos;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.UserRepos
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<string> Login(LoginDto dto);
        Task<bool> register(User user);
    }
}
