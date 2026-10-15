using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.RideRepos
{
    public interface IRideRepo : IGenericRepo<Ride>
    {
        Task<List<Ride>> PagedRides(int pageNumber, int pageSize);
        Task<List<Ride>> Search(string PakcUp);
        //Task<List<Ride>> Filter(string Status, decimal minf, decimal maxf, string SortBy);
    }
}
