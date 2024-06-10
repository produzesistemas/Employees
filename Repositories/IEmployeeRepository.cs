
namespace Employees.Repositories
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();

    }
}
