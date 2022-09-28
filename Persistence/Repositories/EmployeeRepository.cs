using Domain.Entities;
using Domain.IRepositories;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employees> , IEmployeeRepository
    {
        public EmployeeRepository(LabContext context) : base(context) { }
    }
}
