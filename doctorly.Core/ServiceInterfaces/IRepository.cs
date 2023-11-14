namespace doctorly.Core.ServiceInterfaces
{
    public interface IRepository<T>
    {
        T? Get(int id);

        Task<T?> GetAsync(int id);

        Task<IEnumerable<T?>> GetAllAsync();

        IEnumerable<T> GetAll();
    }
}
