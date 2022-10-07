using Domain.Entities;
using Domain.IRepositories.Base;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        Task<Employees> GetLastEmployee();
    }
}
