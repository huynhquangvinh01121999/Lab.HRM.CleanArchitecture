using Domain.Entities;
using Domain.IRepositories.Base;

namespace Domain.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
    }
}
