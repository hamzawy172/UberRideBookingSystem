namespace UberRideBookingSystem.GenericRepos
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
