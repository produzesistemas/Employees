using Employees.Models;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Employees.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private ISession _session;
        public EmployeeRepository(ISession session) {
        _session = session;
        }
        public async Task Add(Employee entity)
        {
            ITransaction? transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await transaction!.RollbackAsync();
            }
            finally
            {
                transaction!.Dispose();
            }
        }

        public async Task Delete(int id)
        {
            ITransaction? transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var entityBase = await _session.GetAsync<Employee>(id);
                await _session.DeleteAsync(entityBase);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await transaction!.RollbackAsync();
            }
            finally
            {
                transaction!.Dispose();
            }
        }

        public IEnumerable<Employee> GetAll() => _session.Query<Employee>().ToList();

        public async Task<Employee> GetById(int id) => await _session.GetAsync<Employee>(id);

        public async Task Update(Employee entity)
        {
            ITransaction? transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await transaction!.RollbackAsync();
            }
            finally
            {
                transaction!.Dispose();
            }
        }
    }
}
