using Domain.Entities;
using Domain.IRepositories;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(LabContext context) : base(context) { }
    }
}
